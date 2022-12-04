using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick = false;
    public Transform rightPos;
    public Transform leftPos;
    public float maxDis = 1.2f;
    [HideInInspector]
    public SpringJoint2D sp;
    private Rigidbody2D rb;
    public GameObject Band;
    public GameObject boom;
    public GameObject spot;
    public Sprite[] trajectories;
    public SpriteRenderer StretchedBand;

    public LineRenderer line_right;
    public LineRenderer line_Left;

    private Coroutine coroutine;


    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        rb.isKinematic = true;
        Band.SetActive(false);
        StretchedBand.gameObject.SetActive(true);
        isClick = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        coroutine = StartCoroutine(Trajectory());
        Band.SetActive(true);
        StretchedBand.gameObject.SetActive(false);
        isClick = false;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);
        //prohibit the line components
        line_right.enabled = false;
        line_Left.enabled = false;
        if (GameManager._instance.spots != null)
        {
            for (int i = 0; i < GameManager._instance.spots.Count; i++)
            {
                Destroy(GameManager._instance.spots[i]);
            }
            GameManager._instance.spots.Clear();
        }
    }

    private void Update()
    {
        if (isClick)
        {
            StretchedBand.transform.position = new Vector2(GetComponent<SpriteRenderer>().bounds.min.x, GetComponent<SpriteRenderer>().bounds.center.y);
            //keep tracking the position of the mouse while pressing
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);
            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                //Restraining dragging distance
                Vector3 pos = (transform.position - rightPos.position).normalized;//Find the direction of dragging 
                pos *= maxDis;//maximum length vector;
                transform.position = pos + rightPos.position;
            }
            lineRender();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(coroutine != null)StopCoroutine(coroutine);
    }

    void Fly()
    {
        sp.enabled = false;
        Invoke("Next", 5f);
    }

    void lineRender()
    {
        line_right.enabled = true;
        line_Left.enabled = true;
        line_right.SetPosition(0, rightPos.position);
        line_right.SetPosition(1, StretchedBand.transform.position);
        line_Left.SetPosition(0, leftPos.position);
        line_Left.SetPosition(1, StretchedBand.transform.position);
    }

    //Switching the birds
    void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    IEnumerator Trajectory()
    {
        int i = 0;
        while(i < trajectories.Length)
        {
            Debug.Log("running");
            spot.GetComponent<SpriteRenderer>().sprite = trajectories[i];
            yield return new WaitForSeconds(.05f);
            GameManager._instance.spots.Add(Instantiate(spot, transform.position, Quaternion.identity));
            i++;
            if (i == trajectories.Length - 1) i = 0;
        }
    }
}

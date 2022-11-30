using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick = false;
    public Transform rightPos;
    public Transform leftPos;
    public float maxDis = 1.2f;
    private SpringJoint2D sp;
    private Rigidbody2D rb;
    public GameObject Band;
    public SpriteRenderer StretchedBand;

    public LineRenderer line_right;
    public LineRenderer line_Left;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Band.SetActive(false);
        StretchedBand.gameObject.SetActive(true);
        isClick = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        Band.SetActive(true);
        StretchedBand.gameObject.SetActive(false);
        isClick = false;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);
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

    void Fly()
    {
        sp.enabled = false;
    }

    void lineRender()
    {
        line_right.SetPosition(0, rightPos.position);
        line_right.SetPosition(1, StretchedBand.transform.position);
        line_Left.SetPosition(0, leftPos.position);
        line_Left.SetPosition(1, StretchedBand.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick = false;
    public Transform rightPos;
    public float maxDis = 1.2f;
    private SpringJoint2D sp;
    private Rigidbody2D rb;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        isClick = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);
    }

    private void Update()
    {
        if (isClick)
        {
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
        } 

    }

    void Fly()
    {
        sp.enabled = false;
    }
}

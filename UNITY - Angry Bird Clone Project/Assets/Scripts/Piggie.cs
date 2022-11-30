using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggie : MonoBehaviour
{
    public float MaxSpeed = 10;
    public float MinSpeed = 5;
    private SpriteRenderer render;
    public Sprite Hurt;
    public GameObject Boom;
    public float HP = 2;
    public GameObject score;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.sqrMagnitude > MaxSpeed) //if velocity of collision is LESS THAN speed/force threshold, don't register the hit
        {
            HP = 0;
        } else if (collision.relativeVelocity.sqrMagnitude < MaxSpeed && collision.relativeVelocity.sqrMagnitude > MinSpeed)
        {
            render.sprite = Hurt;
            HP--;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(Boom, transform.position, Quaternion.identity);
        GameObject _score = Instantiate(score, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(_score, 1.5f);
    }
}

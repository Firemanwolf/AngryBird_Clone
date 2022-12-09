using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piggie : MonoBehaviour
{
    public float MaxSpeed = 10;
    public float MinSpeed = 5;
    private SpriteRenderer render;
    public List<Sprite> Hurt;
    public GameObject Boom;
    public float HP = 2;
    public GameObject score;
    private int spriteIndex = -1;

    public bool isPiggy;

    public Text ScoreText;
    private static int ScoreNum;

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
            spriteIndex++;
            if(spriteIndex<Hurt.Count)render.sprite = Hurt[spriteIndex];
            HP--;
        }
    }

    public void Die()
    {
        if (isPiggy){
        ScoreNum += 5000;
        ScoreText.text = "Score: " + ScoreNum;
        Debug.Log("Score Registered!");
        GameManager._instance.pigs.Remove(this);
        } 
        Destroy(gameObject);
        Instantiate(Boom, transform.position, Quaternion.identity);
        GameObject _score = Instantiate(score, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(_score, 1.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    private int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        ScoreText.text = "Score: " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Pig)
    {
        if (Pig.tag == "Enemy")
        {
            ScoreNum += 5000;
            Destroy(Pig.gameObject);
            ScoreText.text = "Score: " + ScoreNum;
        }
    }
}

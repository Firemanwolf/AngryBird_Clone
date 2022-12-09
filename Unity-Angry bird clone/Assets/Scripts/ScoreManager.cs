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

    public void Die()
    {
        {
            ScoreNum += 5000;
            ScoreText.text = "Score: " + ScoreNum;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public Text ScoreText;
    public static int ScoreNum;

    public Text FScoreText;
    public static int FScoreNum;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void PauseGame()
    {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

       public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

       public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            GameIsPaused = false;
            ScoreNum = 0;
            ScoreText.text = "Score: " + ScoreNum;
            FScoreNum = 0;
            FScoreText.text = "Score: " + FScoreNum;
        }
    }
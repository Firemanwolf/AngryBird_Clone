using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space))
      //  {
      //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      //  }

        if (SceneManager.GetActiveScene().name == "03-Cutscene")
            BGMusic.instance.GetComponent<AudioSource>().Pause();
        

    }
}

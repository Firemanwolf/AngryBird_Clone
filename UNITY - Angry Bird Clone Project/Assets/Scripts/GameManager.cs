using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        DontDestroyOnLoad(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Piggie> pigs;
    public static GameManager _instance;
    public static bool gamePaused;
    private Vector3 InitPos;
    public List<GameObject> spots;

    private void Awake()
    {
        _instance = this;
        if(birds.Count > 0)InitPos = birds[0].transform.position;
        spots = new List<GameObject>();
    }
    void Start()
    {
        gamePaused = false;
        DontDestroyOnLoad(gameObject);
        Initialized();
    }

    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if(i == 0)
            {
                birds[i].transform.position = InitPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        } 
    }

    public void NextBird()
    {
        if (pigs.Count > 0)
        {
            //letting next bird to fly
            if(birds.Count > 0)
            {
                Initialized();
            }
        } else
        {
            //win
        }
    }
}

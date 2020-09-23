using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private float _timeRemaining;
    private float maxTime = 2 * 60;
    private int numCoins;

    private void Start()
    {
        TimeRemaining = maxTime;
    }

    public void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if(TimeRemaining <= 0)
        {
            EditorSceneManager.GetActiveScene();
            TimeRemaining = maxTime;
        }
    }

    public float TimeRemaining
    {
        get 
        { 
            return _timeRemaining; 
        }
        set
        {
            _timeRemaining = value;
        }
    }

    public int NumCoins
    {
        get
        {
            return numCoins;
        }
        set
        {
            numCoins = value;
        }
    }

}

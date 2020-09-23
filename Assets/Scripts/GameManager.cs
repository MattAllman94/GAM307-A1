using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private float _timeRemaining;
    private float maxTime = 2 * 60;

    private void Start()
    {
        TimeRemaining = maxTime;
    }

    public void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if(TimeRemaining <= 0)
        {
            EditorSceneManager.LoadScene(this);
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



}

﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
//using UnityEditor.SceneManagement; -> Wont build with this code
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    public Text timerLabel;
    public Text coinLabel;
    public Text healthLabel;

    public GameObject wonGamePanel;
    public GameObject titlePanel; //added title panel
    public GameObject loseGamePanel; //added lose panel
    public GameObject pausePanel; //added pause menu
    

       
    void Update()
    {
        timerLabel.text = FormatTime(GameManager.instance.TimeRemaining);
        coinLabel.text = GameManager.instance.NumCoins.ToString();
        healthLabel.text = FormatHealth(GameManager.instance.GetPlayerHealthPercentage());

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0} : {1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }

    private string FormatHealth(float healthPercentage)
    {
        return string.Format("{0}%", Mathf.RoundToInt(healthPercentage * 100));
    }

   
    public void PlayGame() //Starts the game when the play button is pressed
    {
        titlePanel.SetActive(false);
        Time.timeScale = 1f; //starts the game timer
        FindObjectOfType<GameManager>().player.SetActive(true); //sets the player model to active so the camera starts pointing forward rather than the ground
        
    }

    public void QuitGame() //Allows for the game to quit when the Exit button is pressed
    {
        Application.Quit();
        //Debug.Log("Quit Game");
    }

    public void Restart() //Restarts the game after winning (Restarting isn't working)
    {
        //EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name); -> Wont Build With this line of code
        titlePanel.SetActive(false);
        Time.timeScale = 0f;
        FindObjectOfType<GameManager>().player.SetActive(true);
       
        
    }

    public void Pause() //controls the pause menu
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Resume() //resumes the game
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.SceneManagement;
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
    
    public GameObject titleCamera; //added to enable the player to be disabled when on title screen

       
    void Update()
    {
        timerLabel.text = FormatTime(GameManager.instance.TimeRemaining);
        coinLabel.text = GameManager.instance.NumCoins.ToString();
        healthLabel.text = FormatHealth(GameManager.instance.GetPlayerHealthPercentage());
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
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().player.SetActive(true);
        titleCamera.SetActive(false);
    }

    public void QuitGame() //Allows for the game to quit when the Exit button is pressed
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void Restart() //Restarts the game after winning (Restarting isn't working)
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
        titlePanel.SetActive(false);
        Time.timeScale = 0f;
        FindObjectOfType<GameManager>().player.SetActive(true);
        titleCamera.SetActive(false);
        
    }

    
}

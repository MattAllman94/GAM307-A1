using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEditor.SceneManagement;
using UnityEngine;



public class GameManager : Singleton<GameManager>
{
    public GameObject player; //added to be able to disable when in title screen

    private float _timeRemaining;
    private float maxTime = 2 * 60;
   
    private int numCoins;
    private int totalCoinsInLevel;
   
    private int maxHealth = 5;
    private bool isInvulnerable = false;

    private bool gameOver = false;

    

    private void Start()
    {
        
        FindObjectOfType<UpdateUI>().wonGamePanel.SetActive(false);
        FindObjectOfType<UpdateUI>().loseGamePanel.SetActive(false);
        player.SetActive(false);

        Time.timeScale = 0f;
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
        totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if(TimeRemaining <= 0)
        {
            FindObjectOfType<UpdateUI>().loseGamePanel.SetActive(true); //lose screen shows when time hits 0
            Time.timeScale = 0f;
            TimeRemaining = maxTime; //resets time
            PlayerHealth = maxHealth; //resets health
        }

        if(numCoins == totalCoinsInLevel && !gameOver)
        {
            WonGame();
        }
    }

    /*  - Old Restart Code
    public void Restart()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
        //print("Restart Game");
    } */

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

    private float _playerHealth;

    public float PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }

    private void DecrementPlayerHealth(GameObject player)
    {
        if(isInvulnerable)
        {
            return;
        }

        StartCoroutine(InvulnerableDelay());
        
        PlayerHealth--;

        if(PlayerHealth <= 0)
        {
            FindObjectOfType<UpdateUI>().loseGamePanel.SetActive(true); //lose screen shows when health hits 0
            Time.timeScale = 0f;
            TimeRemaining = maxTime;
            PlayerHealth = maxHealth;
        }
    }

    public float GetPlayerHealthPercentage()
    {
        return PlayerHealth / (float)maxHealth;
    }

   

    void OnEnable()
    {
        DamagePlayerEvent.OnDamagePlayer += DecrementPlayerHealth;
        
    }

    void OnDisable()
    {
        DamagePlayerEvent.OnDamagePlayer -= DecrementPlayerHealth;
        
    }

    private IEnumerator InvulnerableDelay()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(1.0f);
        isInvulnerable = false;
    }

    private void WonGame()
    {
        gameOver = true;
        FindObjectOfType<UpdateUI>().wonGamePanel.SetActive(true);
        //yield return new WaitForSeconds(3);  -> Original Code
        //Restart(); -> Original Code
        Time.timeScale = 0f;
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
        
    }
}

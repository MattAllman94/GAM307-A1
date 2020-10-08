using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private float _timeRemaining;
    private float maxTime = 2 * 60;
    private int numCoins;
    private int maxHealth = 5;
    private bool isInvulnerable = false;

    private void Start()
    {
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
    }

    public void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if(TimeRemaining <= 0)
        {
            Restart();
        }
    }

    public void Restart()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
        print("Restart Game");
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
            Restart();
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
}

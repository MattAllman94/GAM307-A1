using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    public Text timerLabel;
    public Text coinLabel;
    public Text healthLabel;
    public GameObject wonGamePanel;
    public GameObject titlePanel;
       
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
}

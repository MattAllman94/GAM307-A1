using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    public Text timerLabel;
    public Text coinLabel;
       
    void Update()
    {
        timerLabel.text = FormatTime(GameManager.instance.TimeRemaining);
        coinLabel.text = GameManager.instance.NumCoins.ToString();
    }

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0} : {1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }
}

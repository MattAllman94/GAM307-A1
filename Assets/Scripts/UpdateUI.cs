using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    public Text timerLabel;
       
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerLabel.text = FormatTime(GameManager.instance.TimeRemaining);
    }

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("(0) : (1:00)", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }
}

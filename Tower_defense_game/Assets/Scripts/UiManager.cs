using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI TimerTextObj;

    public static UiManager instance;

    void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
    }

    public void SetTimerText(float time){
        string timerTime = (Mathf.Floor(time)+1).ToString();
        TimerTextObj.text = timerTime;
    }
}

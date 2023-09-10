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

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI goldText;



    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start(){
        SetGoldText(GameManager.instance.GetGold().ToString());
        SetHealthText(GameManager.instance.GetHealth().ToString());
    }

    public void SetTimerText(float time)
    {
        string timerTime = (Mathf.Floor(time) + 1).ToString();
        TimerTextObj.text = timerTime;
    }

    public void SetTimerText(string time){
        TimerTextObj.text = time;
    }

    public void ConstructorTowerWasClicked(GameObject constructor)
    {
        Construction myConstructorTower = constructor.GetComponent<Construction>();
        Debug.Log(myConstructorTower.getTowers());
    }

    public void ConstructorUIButtonClicked(){
        Debug.Log("CLICKED UI BUTTON");
    }

    public void SetHealthText(string newHealthText){
        healthText.text = newHealthText;
    }
    public void SetGoldText(string newGoldText){
        goldText.text = newGoldText;
    }
    public void DisableTimerText(){
        TimerTextObj.gameObject.SetActive(false);
    }
    public void EnableTimerText(){
        TimerTextObj.gameObject.SetActive(true);
    }
    public void UpdateHealthText(){
        healthText.text = GameManager.instance.GetHealth().ToString();
    }
    
}

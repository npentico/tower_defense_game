using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    int maxValue;

    [SerializeField] Slider mySlider;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        if (enemy)
        {
            maxValue = enemy.getMaxHealth();
        }
       mySlider.maxValue=enemy.getMaxHealth();
        

    }

    
    void Update()
    {
        mySlider.value= enemy.GetCurrentHealth();
    }
}

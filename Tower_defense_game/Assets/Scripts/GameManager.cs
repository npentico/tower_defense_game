using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] int Health;
    [SerializeField] int MaxHealth = 50;

    [Header("Economy")]
    [SerializeField] int Gold = 100;
    
     public static GameManager instance;
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
    void Start()
    {
        Health = MaxHealth;

    }

    public void DoDamageToPlayer(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            //YOU LOSE
            Debug.Log("Lose state");

        }

    }
    public int GetHealth() { return Health; }

    //spends gold if theres gold to spend and returns false otherwise
    public bool SpendGold(int goldToSpend){
        if(goldToSpend - goldToSpend >0){
            Gold -= goldToSpend;
            return true;
        }
        else return false;
    }

    public void AddGold(int goldToAdd){Gold+=goldToAdd;}
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] int Health;
    [SerializeField] int MaxHealth = 50;

    [Header("Economy")]
    [SerializeField] int Gold = 100;

    [SerializeField] List<GameObject> baseTowerPrefabs;
    
     public static GameManager instance;
     List<GameObject> enemyList;

     public bool gameStarted = false;
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
        if(Gold - goldToSpend >=0){
            Gold -= goldToSpend;
            return true;
        }
        else return false;
    }

    public void AddGold(int goldToAdd){Gold+=goldToAdd;}
    public int GetGold() { return Gold;}    
    public void StartGame(){
        gameStarted = true;
        UiManager.instance.EnableTimerText();
        UiManager.instance.DisableSpawnWaveButton();
    }

    public List<GameObject> GetBaseTowers(){
        
        return baseTowerPrefabs;
    }

    public void AddEnemyToList(GameObject enemy){
        enemyList.Add(enemy);
    }
    
    

   
}

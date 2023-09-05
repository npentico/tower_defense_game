using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int Health;
    [SerializeField] int MaxHealth = 50;
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
}

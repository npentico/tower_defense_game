using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other);
        if(other.tag == "Enemy"){
            GameManager.instance.DoDamageToPlayer(1);
        }
    }
    
}
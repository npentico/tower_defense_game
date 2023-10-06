using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeScript : MonoBehaviour
{
  List<GameObject> enemiesInRange;

    void Awake(){
        enemiesInRange = new List<GameObject>();
    }

  public List<GameObject> getEnemiesInRange(){
    return enemiesInRange;
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.tag == "Enemy"){
        enemiesInRange.Add(other.gameObject);
    }
  }

  void OnTriggerExit2D(Collider2D other){
    enemiesInRange.Remove(other.gameObject);
  }

  public bool IsEnemyInRange(GameObject enemy){
    
    if(enemiesInRange.Contains(enemy)){
        return true;
    }
    else{
        return false;
    }
   
  }
  void OnMouseDown(){
    Debug.Log("CLICKED RANGE");
  }
}

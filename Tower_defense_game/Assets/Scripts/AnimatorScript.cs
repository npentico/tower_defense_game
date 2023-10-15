using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    [SerializeField] TowerScript myTower;
   
  public void testAnimator(){
    Debug.Log(myTower.name + " firing");
        myTower.FireTurretShot();
        
    }
}

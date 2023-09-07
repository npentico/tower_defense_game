using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIButton : MonoBehaviour
{
   [SerializeField] GameObject constructorTower;
   [SerializeField] Sprite confirmSprite;

   bool confirm = false;



   public void SetConstructorTower(GameObject tower){
        constructorTower= tower;
        
   }  

   




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tower Stats",fileName ="new Tower Stats")]
public class TowerStats : ScriptableObject
{
    [SerializeField] float reloadTime;
    [SerializeField] int damage;
    [SerializeField] int purchaseCost;
    [SerializeField] Sprite towerSprite;

     [TextArea][SerializeField] string description;

     public float getReloadTime(){return reloadTime;}
     public float getDamage(){return damage;}   
     public int getPurchaseCost(){return purchaseCost;}
     public string getDescription(){return description;}  

     public Sprite GetSprite(){return towerSprite;}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(menuName ="Tower Stats",fileName ="new Tower Stats")]
public class TowerStats : ScriptableObject
{
    [SerializeField] float reloadTime;
    [SerializeField] int damage;
    [SerializeField] int purchaseCost;
    [SerializeField] Sprite towerSprite;

    [SerializeField] Image upgradeImage;

     [TextArea][SerializeField] string description;

     [SerializeField] AudioClip towerConstruction;

     public float GetReloadTime(){return reloadTime;}
     public float GetDamage(){return damage;}   
     public int GetPurchaseCost(){return purchaseCost;}
     public string GetDescription(){return description;}  

     public Sprite GetSprite(){return towerSprite;}

     public AudioClip getConstructionSound(){
        return towerConstruction;
     }

     public Image getUpgradeImage(){
      return upgradeImage;
     }

     


}

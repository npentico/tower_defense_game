using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Construction : MonoBehaviour
{
   [SerializeField] List<GameObject> towersCanSpawnPrefabs;
   [SerializeField] float yOffset = 0f;

   [SerializeField] GameObject spriteCanvas;

   [SerializeField] Image spriteImage;

   [SerializeField]GameObject checkMark;

    public void ConstructorButtonClicked(){
        
    //   /  spriteCanvas.SetActive(!spriteCanvas.activeSelf);
    }


   public void BuyTower(GameObject towerToBuy){
    TowerStats stats = towerToBuy.GetComponent<TowerScript>().GetTowerStats();
        if(GameManager.instance.GetGold()>= stats.GetPurchaseCost()){
            Vector3 position = transform.position;
            position.y += yOffset;
           Instantiate(towerToBuy,position,Quaternion.identity);
            GameManager.instance.SpendGold(stats.GetPurchaseCost());
            UiManager.instance.SetGoldText(GameManager.instance.GetGold().ToString());
            AudioManager.instance.PlaySoundClip(stats.getConstructionSound(),.5f);
            
        }
   }

   public List<GameObject> getTowers(){
    return towersCanSpawnPrefabs;
   }
   
}

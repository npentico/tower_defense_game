using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
   [SerializeField] List<GameObject> towersCanSpawnPrefabs;
   [SerializeField] float yOffset = 1.15f;
   

    

    public void ConstructorButtonClicked(){
        Debug.Log("ClickedConstructor");
    }

    void OnMouseDown()
   {
       ConstructorButtonClicked();
       UiManager.instance.ConstructorTowerWasClicked(gameObject);
       BuyTower(towersCanSpawnPrefabs[0]);
   }

    //the hard commit will create the tower
   void BuyTower(GameObject towerToBuy){
    TowerStats stats = towerToBuy.GetComponent<TowerScript>().GetTowerStats();
        if(GameManager.instance.GetGold()>= stats.getPurchaseCost()){
            Vector3 position = transform.position;
            position.y += yOffset;
           Instantiate(towerToBuy,position,Quaternion.identity);
            GameManager.instance.SpendGold(stats.getPurchaseCost());
            UiManager.instance.SetGoldText(GameManager.instance.GetGold().ToString());
            this.gameObject.SetActive(false);
        }
   }

   public List<GameObject> getTowers(){
    return towersCanSpawnPrefabs;
   }
}

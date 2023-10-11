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

    [SerializeField] GameObject checkMark;

    public void ConstructorButtonClicked()
    {

        //   /  spriteCanvas.SetActive(!spriteCanvas.activeSelf);
    }


    public void BuyTower(GameObject towerToBuy)
    {
        TowerStats stats = towerToBuy.GetComponentInChildren<TowerScript>().GetTowerStats();
        if (GameManager.instance.GetGold() >= stats.GetPurchaseCost())
        {
            Vector3 position = transform.position;
            position.y += yOffset;
            Instantiate(towerToBuy, position, Quaternion.identity);
            int goldToSpend = stats.GetPurchaseCost();
            GameManager.instance.SpendGold(goldToSpend);
            EventManager.instance.ChangeGold(goldToSpend * -1);
            AudioManager.instance.PlaySoundClip(stats.getConstructionSound(), .5f);

        }
    }

    public List<GameObject> getTowers()
    {
        return towersCanSpawnPrefabs;
    }

}

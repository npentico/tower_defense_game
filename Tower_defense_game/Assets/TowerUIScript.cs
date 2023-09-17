
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIScript : MonoBehaviour
{
    [SerializeField] GameObject CanvasAndLayoutGroup;
    [SerializeField] GameObject UiButtonPrefab;
    [SerializeField] Canvas upgradeCanvas;

    List<GameObject> potentialUpgrades;
    void Start()
    {
        InstantiateUpgradeCanvas();

    }

     void OnMouseDown()
    {
        Debug.Log("Clicked tower");
        if (upgradeCanvas.gameObject.activeSelf)
        {
            upgradeCanvas.gameObject.SetActive(false);
        }
        else
        {
            upgradeCanvas.gameObject.SetActive(true);
        }

    }

    void InstantiateUpgradeCanvas()
    {
        LayoutGroup layoutGroup = upgradeCanvas.GetComponentInChildren<LayoutGroup>();
        List<GameObject> myPotentialTowers = GetComponent<TowerScript>().GetUpgrades();
        Debug.Log(layoutGroup);
        foreach (GameObject tower in myPotentialTowers)
        {
            GameObject uiElement = Instantiate(UiButtonPrefab, layoutGroup.transform);
            UpgradeButtonScript myButton = uiElement.GetComponent<UpgradeButtonScript>();
            TowerStats newStats = tower.GetComponent<TowerScript>().GetTowerStats();
            myButton.SetSpriteImage(newStats.getUpgradeImage());
            myButton.SetPriceText(newStats.getPurchaseCost());
            myButton.SetCallingTower(gameObject);
            myButton.SetTower(tower);
            
            //set up ui for each upgrade
        }
    }

    public void ReplaceTower(GameObject newTower){
        GameObject myNewTower = Instantiate(newTower,transform.position,Quaternion.identity);
        Destroy(gameObject);

        
    }

}


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIScript : MonoBehaviour
{
    [SerializeField] GameObject CanvasAndLayoutGroup;
    [SerializeField] GameObject UiButtonPrefab;
    GameObject upgradeCanvas;

    void Start()
    {
        InstantiateUpgradeCanvas();

    }

    void OnMouseDown()
    {
        Debug.Log("Clicked tower");
        if (upgradeCanvas.gameObject.activeSelf)
        {
            upgradeCanvas.SetActive(false);
        }
        else
        {
            upgradeCanvas.SetActive(true);
        }

    }

    void InstantiateUpgradeCanvas()
    {
        Vector3 canvasPosition = transform.position;
        canvasPosition.y += 0.6f;
        upgradeCanvas = Instantiate(CanvasAndLayoutGroup,canvasPosition,Quaternion.identity);
        List<GameObject> myPotentialTowers;
        LayoutGroup layoutGroup = upgradeCanvas.GetComponentInChildren<LayoutGroup>();
     //           LayoutGroup layoutGroup = testUpgradeCanvas.GetComponentInChildren<LayoutGroup>();

        if (GetComponent<Construction>() != null)
        {
            //do constructor tile things
            Debug.Log("In construction not upgrade");
            myPotentialTowers = GameManager.instance.GetBaseTowers();
            Debug.Log(myPotentialTowers);
            Debug.Log(layoutGroup);
            CreateUI(myPotentialTowers, layoutGroup);

        }
        else if (GetComponent<TowerScript>() != null)
        {
            //     LayoutGroup layoutGroup = upgradeCanvas.GetComponentInChildren<LayoutGroup>();
            myPotentialTowers = GetComponent<TowerScript>().GetUpgrades();
            CreateUI(myPotentialTowers, layoutGroup);


        }
        


    }

    void CreateUI(List<GameObject> myTowers, LayoutGroup layoutGroup)
    {
        foreach (GameObject tower in myTowers)
        {
            Debug.Log(tower);
            GameObject uiElement = Instantiate(UiButtonPrefab, layoutGroup.transform);
            UpgradeButtonScript myButton = uiElement.GetComponent<UpgradeButtonScript>();
            TowerStats newStats = tower.GetComponentInChildren<TowerScript>().GetTowerStats();
            Debug.Log(newStats);
            myButton.SetSpriteImage(newStats.getUpgradeImage());
            myButton.SetPriceText(newStats.GetPurchaseCost());
            myButton.SetCallingTower(gameObject);
            myButton.SetTower(tower);

            //set up ui for each upgrade
        }
    }

    public void ReplaceTower(GameObject newTower)
    {
        Debug.Log("In replace tower");


        if (GetComponent<Construction>() != null)
        {
            GetComponent<Construction>().BuyTower(newTower);
        }
        else
        {
            GameObject myNewTower = Instantiate(newTower, transform.position, Quaternion.identity);
            GameManager.instance.SpendGold(newTower.GetComponentInChildren<TowerScript>().GetTowerStats().GetPurchaseCost());
            UiManager.instance.UpdateGoldText();

        }

        gameObject.SetActive(false);
         Destroy(upgradeCanvas);
         Destroy(transform.parent.gameObject);
        
       


    }

}

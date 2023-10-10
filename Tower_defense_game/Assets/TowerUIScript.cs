
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerUIScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject CanvasAndLayoutGroup;
    [SerializeField] GameObject UiButtonPrefab;
    GameObject upgradeCanvas;

    void Start()
    {
        InstantiateUpgradeCanvas();

    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (gameObject.layer != LayerMask.NameToLayer("Range"))
        {
            if (upgradeCanvas.gameObject.activeSelf)
            {
                upgradeCanvas.SetActive(false);
            }
            else
            {
                upgradeCanvas.SetActive(true);
            }
        }
    }

    /*void OnMouseDown()
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

   }*/

    void InstantiateUpgradeCanvas()
    {
        Vector3 canvasPosition = transform.position;
        canvasPosition.y += 0.6f;
        upgradeCanvas = Instantiate(CanvasAndLayoutGroup, canvasPosition, Quaternion.identity);
        List<GameObject> myPotentialTowers;
        LayoutGroup layoutGroup = upgradeCanvas.GetComponentInChildren<LayoutGroup>();
        //           LayoutGroup layoutGroup = testUpgradeCanvas.GetComponentInChildren<LayoutGroup>();

        if (GetComponent<Construction>() != null)
        {
            //do constructor tile things
      //      Debug.Log("In construction not upgrade");
            myPotentialTowers = GameManager.instance.GetBaseTowers();
            
            CreateUI(myPotentialTowers, layoutGroup);

        }
        else if (GetComponent<TowerScript>() != null)
        {
            //     LayoutGroup layoutGroup = upgradeCanvas.GetComponentInChildren<LayoutGroup>();
            myPotentialTowers = GetComponent<TowerScript>().GetUpgrades();
       //     Debug.Log(myPotentialTowers + "IN TOWER UPGRADES");
            CreateUI(myPotentialTowers, layoutGroup);


        }



    }

    void CreateUI(List<GameObject> myTowers, LayoutGroup layoutGroup)
    {
        foreach (GameObject tower in myTowers)
        {
        
            GameObject uiElement = Instantiate(UiButtonPrefab, layoutGroup.transform);
            UpgradeButtonScript myButton = uiElement.GetComponent<UpgradeButtonScript>();
            TowerStats newStats = tower.GetComponent<TowerScript>().GetTowerStats();
//            Debug.Log(newStats);
            
            myButton.SetSpriteImage(newStats.getUpgradeImage());
            myButton.SetPriceText(newStats.GetPurchaseCost());
            myButton.SetCallingTower(gameObject);
            myButton.SetTower(tower);

            //set up ui for each upgrade
        }
    }

    public void ReplaceTower(GameObject newTower)
    {
      //  Debug.Log("In replace tower");


        if (GetComponent<Construction>() != null)
        {
            GetComponent<Construction>().BuyTower(newTower);
        }
        else
        {
            GameObject myNewTower = Instantiate(newTower, transform.position, Quaternion.identity);
            GameManager.instance.SpendGold(newTower.GetComponent<TowerScript>().GetTowerStats().GetPurchaseCost());
            UiManager.instance.UpdateGoldText();

        }

        gameObject.SetActive(false);
        Destroy(upgradeCanvas);
        Destroy(transform.gameObject);




    }

}

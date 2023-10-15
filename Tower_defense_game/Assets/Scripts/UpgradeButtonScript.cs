using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour
{
    Image spriteImage;
    TowerScript myTower;
    TowerUIScript myTowerUI;

    [SerializeField]GameObject towerOnButton;

    [SerializeField] int purchaseCost;

    void Update(){
        if(GameManager.instance.GetGold() < purchaseCost){
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    [SerializeField] TextMeshProUGUI priceText;
    void Awake(){
        spriteImage = GetComponent<Image>();
        
    }

    public void SetTower(GameObject tower){
        towerOnButton = tower;
    }
    public void SetSpriteImage(Image spriteToSet){
        spriteImage = spriteToSet;
    }

    public void SetPriceText(string text){
        priceText.text = text;
        
    }

    public void SetPriceText(int price){
        priceText.text = price.ToString();
        purchaseCost = price;
    }

    public void SetCallingTower(TowerScript tower){
        myTower=tower;
    }

    public void SetCallingTower(GameObject tower){
        myTower = tower.GetComponent<TowerScript>();
        myTowerUI =tower.GetComponent<TowerUIScript>();
    }

    public void ClickedButton(){
      //  Debug.Log("clicked button");
        myTowerUI.ReplaceTower(towerOnButton);
    }
}

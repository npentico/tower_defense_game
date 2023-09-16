using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour
{
    Image spriteImage;

    [SerializeField] TextMeshProUGUI priceText;
    void Awake(){
        spriteImage = GetComponent<Image>();
    }
    public void SetSpriteImage(Image spriteToSet){
        spriteImage = spriteToSet;
    }

    public void SetPriceText(string text){
        priceText.text = text;
    }

    public void SetPriceText(int price){
        priceText.text = price.ToString();
    }

    public void ClickedButton(){
        Debug.Log("clicked button");
    }
}

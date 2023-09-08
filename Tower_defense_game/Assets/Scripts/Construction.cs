using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Construction : MonoBehaviour
{
   [SerializeField] List<GameObject> towersCanSpawnPrefabs;
   [SerializeField] float yOffset = 1.15f;

   [SerializeField] GameObject spriteCanvas;

   [SerializeField] Image spriteImage;

   [SerializeField]GameObject checkMark;

   bool showingButtons = false;
   Camera m_Camera;
   

    

    public void ConstructorButtonClicked(){
        
        spriteCanvas.SetActive(!spriteCanvas.activeSelf);
    }

   void Awake()
   {
       m_Camera = Camera.main;
   }

   //WIP TO TURN OFF BUTTONS WHEN YOU CLICK SOMETHING NOT THE TOWER OR THE UI ELEMENTS
   /*void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
        
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
           RaycastHit2D hit2d =  Physics2D.Raycast(m_Camera.transform.position, worldPosition);
        
           
            if(hit2d.collider != null && hit2d.collider.gameObject == gameObject){
                Debug.Log(hit2d.transform.gameObject.name);
                spriteCanvas.SetActive(true);
            }
            
            //if you click nothing
            else {
                spriteCanvas.SetActive(false);  
            }
           
             
       }
   }*/

    void OnMouseDown()
   {
       ConstructorButtonClicked();
      

    //   UiManager.instance.ConstructorTowerWasClicked(gameObject);
      // BuyTower(towersCanSpawnPrefabs[0]);
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

   public void ClickedLittleButton(){
    EnableCheckMark();

   }

   public void ClickedCheckMark(){
    Debug.Log("Clicked Check Mark");
    BuyTower(towersCanSpawnPrefabs[0]);
   }

   public void DisableCheckMark(){ checkMark.SetActive(false); }
   public void EnableCheckMark() { checkMark.SetActive(true); }

   
}

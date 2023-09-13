using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Stats and Reference")]
    [SerializeField] TowerStats myStats;
    [SerializeField] RangeScript myTowerRange;
    List<GameObject> enemiesInRange;

   [Header("Current Target")]

    [SerializeField] GameObject currentEnemy = null;
    [Header("Weapon and Projectile")]
    [SerializeField] GameObject projectilePrefab;
     [SerializeField] GameObject weapon;

     [SerializeField] Animator myAnimator;
     

     float reloadTime;
    float timer;
    void Awake()
    {
        enemiesInRange = new List<GameObject>();
        reloadTime= myStats.getReloadTime();
        timer =reloadTime;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesInRange = myTowerRange.getEnemiesInRange();
        if(currentEnemy!=null){
            if(!myTowerRange.IsEnemyInRange(currentEnemy.gameObject)){
                currentEnemy = null;
            }
           
        }
        if(enemiesInRange.Count > 0){

            if(currentEnemy == null){
                currentEnemy = enemiesInRange[0].gameObject;
            }
        }
        if(currentEnemy){
            Debug.DrawLine(transform.position,currentEnemy.transform.position, Color.red);
            if(myAnimator){
                myAnimator.SetBool("Enemies In Range",true);
                
            }
        }
        else{
            if(myAnimator){
                myAnimator.SetBool("Enemies In Range",false);
            }
        }
        timer -= Time.deltaTime;
        if(timer< 0 && currentEnemy){
          if(myAnimator){
            myAnimator.SetTrigger("FireShot");
            timer = reloadTime;
          }
        }
        
    }

    public void FireTurretShot(){

       GameObject projectile = Instantiate(projectilePrefab,weapon.transform.position, Quaternion.identity);  
       projectile.GetComponent<Projectile>().SetTarget(currentEnemy.transform.position); 
       
        if(myAnimator){
           // myAnimator.ResetTrigger("FireShot");
        }

    }

    public void ShowRangeIndicator(){
        GameObject rangeIndicator = transform.Find("Range").gameObject;
        rangeIndicator.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideRangeIndicator(){
         GameObject rangeIndicator = transform.Find("Range").gameObject;
        rangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
    }

    public TowerStats GetTowerStats(){
        return myStats;
    }

    public GameObject GetCurrentTarget(){
        return currentEnemy;
    }
    



}
using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Stats and Reference")]
    [SerializeField] TowerStats myStats;
    [SerializeField] RangeScript myTowerRange;
    List<GameObject> enemiesInRange;

    public bool targetFirst = true;
    [Header("Current Target")]


    [SerializeField] GameObject currentEnemy = null;
    [Header("Weapon and Projectile")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject weapon;

    [SerializeField] Animator myAnimator;

    [SerializeField] List<GameObject> upgrades;

    float reloadTime;
    float timer;
    void Awake()
    {
        enemiesInRange = new List<GameObject>();
        reloadTime = myStats.GetReloadTime();
        timer = reloadTime;
        
    }

    // Update is called once per frame
    
    void Update()

    {
        UpdateTargets();
        
        timer -= Time.deltaTime;
        if (timer < 0 && currentEnemy)
        {
            FireProjectile();
        }

    }
    void FireProjectile()
    {
        if (myAnimator)
        {
           
            myAnimator.SetTrigger("FireShot");
            timer = reloadTime;
        }
    }
    void UpdateTargets()
    {
        //get the list of enemies in range
        enemiesInRange = myTowerRange.getEnemiesInRange();
        SortTargets();
        
        //if there is a current enemy but its not in range null it out
        if (currentEnemy != null)
        {
            if (!myTowerRange.IsEnemyInRange(currentEnemy.gameObject))
            {
                currentEnemy = null;
            }

        }
        //if there are enmies in range and no current target pick the first one in the array
        if (enemiesInRange.Count > 0)
        {

            if (currentEnemy == null)
            {
                currentEnemy = enemiesInRange[0].gameObject;
            }
        }
        if (currentEnemy)
        {
            Debug.DrawLine(transform.position, currentEnemy.transform.position, Color.red);
        }

    }

    public void FireTurretShot()
    {
        GameObject projectile = Instantiate(projectilePrefab, weapon.transform.position, Quaternion.identity);
        if (currentEnemy)
        {
            projectile.GetComponent<Projectile>().SetTarget(currentEnemy);
        }
        else
        {
            Destroy(projectile);
        }
    }

    public void ShowRangeIndicator()
    {
        GameObject rangeIndicator = transform.Find("Range").gameObject;
        rangeIndicator.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideRangeIndicator()
    {
        GameObject rangeIndicator = transform.Find("Range").gameObject;
        rangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
    }

    public TowerStats GetTowerStats()
    {
        return myStats;
    }

    public GameObject GetCurrentTarget()
    {
        return currentEnemy;
    }

    public List<GameObject> GetUpgrades(){
        return upgrades;
    }

    void SortTargets(){
        if(enemiesInRange.Count<=1){
            return;
        }
        if(targetFirst){
            enemiesInRange.Sort(GetFirstEnemySort);
        }
        else{
            enemiesInRange.Sort(GetLastEnemySort);
        }
        Debug.Log("test");
        
       
    }

   

   int GetLastEnemySort(GameObject a, GameObject b){
        float aDistance = a.GetComponent<PathFinder>().GetDistance();
        float bDistance = b.GetComponent<PathFinder>().GetDistance();
        if(aDistance< bDistance){
            return -1;
        }
        else if(aDistance > bDistance){
            return 1;
        }
        else return 0;
    }
     int GetFirstEnemySort(GameObject a, GameObject b){
        float aDistance = a.GetComponent<PathFinder>().GetDistance();
        float bDistance = b.GetComponent<PathFinder>().GetDistance();
        if(aDistance > bDistance){
            return -1;
        }
        else if(aDistance < bDistance){
            return 1;
        }
        else return 0;
    }

   



}

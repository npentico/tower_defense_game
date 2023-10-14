
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public float summonTimerMax = 10f;
    
    float timer;
    RangeScript myRange;
   [SerializeField] int enemiesDied = 0;

    [SerializeField] int maxSummons = 3;

    [SerializeField] GameObject prefabToSummon;

    void Awake(){
        timer = summonTimerMax;
        myRange = GetComponentInChildren<RangeScript>();
        EventManager.OnUnitDied +=UnitWasKilled;

    }
     void OnDisable()
    {
        EventManager.OnUnitDied -= UnitWasKilled;
       
    }

    void Update(){
        timer-= Time.deltaTime;
        if(timer < 0 && enemiesDied > 0){
            SummonEnemies();
            timer = summonTimerMax;
        }
    }

    void SummonEnemies(){
         for(int i=0; i < enemiesDied; i++){
            //spawn the enemy and give it the summoners place along the path
            Vector3 pos = transform.position;
            pos.x += Random.Range(-1.5f,1.5f);
            pos.y += Random.Range(-0.5f,.5f);
            GameObject spawnedEnemy = Instantiate(prefabToSummon,FindObjectOfType<EnemySpawner>().transform);
            //makes sure wave config is set to SUMMONERS wave config not current wave if new wave spawns too soon
            spawnedEnemy.GetComponent<PathFinder>().SetWaveConfig(GetComponent<PathFinder>().GetWaveConfig());
            spawnedEnemy.GetComponent<PathFinder>().SetCurrentWayPointIndex(GetComponent<PathFinder>().GetCurrentWayPointIndex());
            spawnedEnemy.transform.position= pos;

         }
    }

    void UnitWasKilled(GameObject unit){
        if(myRange.IsEnemyInRange(unit)){
            if(enemiesDied < maxSummons){
                enemiesDied++;
            }
        }
    }



    

}

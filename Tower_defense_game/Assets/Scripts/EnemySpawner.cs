using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> wavesToSpawn;
    WaveConfigSO currentWave;
    int waveIndex = 0;
    [SerializeField] bool enemiesAlive = false;
    
    bool WaveIsSpawning = false;

    [SerializeField] bool allWavesSpawned = false;



    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float timer = 2f;

    

    void Update()
    {
        //timer should only count down once wave finishes spawning now.
        if(!GameManager.instance.gameStarted){return;}
        if(!WaveIsSpawning ){
            timer -= Time.deltaTime;
        }
        UiManager.instance.SetTimerText(timer);
        
        if (transform.childCount > 0)
        {
            enemiesAlive = true;
        }
        else
        {
            enemiesAlive = false;
        }
           

        if (timer < 0)
        {
            timer = timeBetweenWaves;
            StartWaveSpawns();
        }
        if(allWavesSpawned && !enemiesAlive){
            Debug.Log("Won!");
            SceneManager.instance.LoadEndingScene();
           
        }


    }

    void StartWaveSpawns()
    {
        if (waveIndex < wavesToSpawn.Count)
        {
            StartCoroutine(SpawnWave());
        }
    }



    IEnumerator SpawnWave()
    {
        currentWave = wavesToSpawn[waveIndex];
        UiManager.instance.DisableTimerText();
       
        WaveIsSpawning = true;
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i), currentWave.getStartingWaypoint().position, Quaternion.identity, transform);
            enemy.GetComponent<PathFinder>().SetWaveConfig(currentWave);
            
            
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
      //  GameManager.instance.AddGold(currentWave.GetGoldValue());
      waveIndex++;
      WaveIsSpawning = false;
      if(waveIndex < wavesToSpawn.Count){
        UiManager.instance.EnableTimerText();
        
      }
      else{
        allWavesSpawned = true;
      }
      
        
    }



    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

   



}

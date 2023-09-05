using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> wavesToSpawn;
    WaveConfigSO currentWave;
    int waveIndex = 0;
    bool enemiesAlive = false;

    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float timer = 2f;

    void Update()
    {
        timer -= Time.deltaTime;
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
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.getStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        waveIndex++;
    }



    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }



}

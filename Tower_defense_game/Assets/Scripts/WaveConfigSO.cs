using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config",fileName ="new Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject>enemyPrefabs;
    [SerializeField] float timeBetweenEnemySpawns = 1f;

    [SerializeField] float spawnTimeVariance =0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    [SerializeField] int WaveGoldValue = 100;

    public Transform getStartingWaypoint(){
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints(){
        List<Transform> myWaypoints = new List<Transform>();
        foreach(Transform t in pathPrefab){
            myWaypoints.Add(t);
        }
        return myWaypoints;
    }

    public int GetEnemyCount(){
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index){
        if(index < enemyPrefabs.Count){
            return enemyPrefabs[index]; 
        }
        else{
            return null;
        }
    }

    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenEnemySpawns-spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    public int GetGoldValue(){return WaveGoldValue;}

    

}

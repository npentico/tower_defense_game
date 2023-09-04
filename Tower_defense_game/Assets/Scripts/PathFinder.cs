using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    Enemy unit;
    

    List<Transform> waypoints;
    [SerializeField] int waypointIndex = 0;
    float speed =1f;
    void Start(){
        waypoints= waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
        unit = GetComponent<Enemy>();
        foreach(Transform myTransform in waypoints){
            Debug.Log(myTransform);
        }

    }
    void Update(){
        FollowPath();
    }

    void FollowPath(){
        if(waypointIndex <waypoints.Count){
            Vector3 targetPosition = waypoints[waypointIndex].position;
           
            float delta = unit.getMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
           
            if(transform.position == targetPosition){
                
                waypointIndex++;
               targetPosition = waypoints[waypointIndex].position;
                 LookAtNextWaypoint(targetPosition);
                Debug.Log("moving towards " + waypoints[waypointIndex]);
            }
        }
        else{
            Destroy(gameObject);
        }
        
    }

    void LookAtNextWaypoint(Vector3 targetPosition){
    //if the waypoint is to the right look right
       if(targetPosition.x > transform.position.x){
         transform.localScale= new Vector3(1,1,1);
       }
       else{
        transform.localScale= new Vector3(-1,1,1);
       }
       //else look left

    }
    
    
    
   
}

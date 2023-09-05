using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    Enemy unit;
    

    List<Transform> waypoints;
    [SerializeField] int waypointIndex = 0;
  
    void Start(){
        waypoints= waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
        unit = GetComponent<Enemy>();
      

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
                if(waypointIndex < waypoints.Count){
                     targetPosition = waypoints[waypointIndex].position;
                    LookAtNextWaypoint(targetPosition);
                }
              
                 
                
            }
        }
        else{
            Destroy(gameObject);
        }
        
    }

    void LookAtNextWaypoint(Vector3 targetPosition){
    //if the waypoint is to the right look right
    Vector3 scale = unit.getInitialScale();
       if(targetPosition.x > transform.position.x){
         transform.localScale= scale;
       }
       else{
        scale.x = -1* scale.x;
        transform.localScale= scale;
       }
       //else look left

    }
    
    
    
   
}

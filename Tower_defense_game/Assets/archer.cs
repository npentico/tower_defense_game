using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class archer : MonoBehaviour
{
    [SerializeField] TowerScript myTower;
  
    Vector3 myScale;
    void Start(){
        myScale= transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = myTower.GetCurrentTarget();
        if(target !=null){
            if(target.transform.position.x > transform.position.x){
             Vector3 newScale = myScale;
             newScale.x*= -1;
             transform.localScale=newScale;
            }
            else{
                transform.localScale = myScale;
            }

        }
    }
}

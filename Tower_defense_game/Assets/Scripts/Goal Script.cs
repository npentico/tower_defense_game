
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other);
        if(other.tag == "Enemy"){
             other.GetComponent<Enemy>().DoDamageToPlayer();
             UiManager.instance.UpdateHealthText();
            
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 target;
    [SerializeField] float lifeSpan = 3f;

    [SerializeField] float projectileSpeed = 1f;

    [SerializeField] int Damage = 5;

    Vector3 myScale;

    void Start(){
        myScale=transform.localScale;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (target != null){
             var step =  projectileSpeed * Time.deltaTime; // calculate distance to move
             transform.position = Vector3.MoveTowards(transform.position, target, step);
             FlipProjectile();
        }
        if(transform.position == target){
            Destroy(gameObject);
        }
        
    }
    public void SetTarget(Vector3 newTarget){target = newTarget;}
    public void SetTarget(GameObject newTarget){
        target=newTarget.transform.position;
    }

    public Projectile(Vector3 newTarget){  target = newTarget;}
    public Projectile(GameObject newTarget){ target = newTarget.transform.position;}

    public int GetDamage(){return Damage;}
    void FlipProjectile(){
        if(target.x > transform.position.x){
             Vector3 newScale = myScale;
             newScale.x*= -1;
             transform.localScale=newScale;
            }
            else{
                transform.localScale = myScale;
            }
    }

    

}

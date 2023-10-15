using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElvenArrow : Projectile
{
     void MoveProjectile()
    {
        // transform.right = target - transform.position;
        if (target != null)
        targetPosition = target.transform.position;
        {
            var step = projectileSpeed * Time.deltaTime; // calculate distance to move
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            
        }


    }
}

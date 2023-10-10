using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject target;

    protected Vector3 targetPosition;
    [SerializeField] protected float lifeSpan = 3f;

    [SerializeField] protected float projectileSpeed = 1f;

    [SerializeField] protected int Damage = 5;

    [SerializeField] protected AudioClip spawnSfx;

    [SerializeField] protected int Pierce = 1;
    protected Vector3 myScale;
    public Projectile()
    {

    }

    void Start()
    {
        targetPosition = target.transform.position;
        myScale = transform.localScale;
        if (spawnSfx)
        {
            AudioManager.instance.PlaySFX(spawnSfx, 0.8f);
        }

        //turns projectile towards target
        Vector3 diff = targetPosition - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rot_z - 120, Vector3.forward);


    }





    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        UpdateLife();
        Debug.DrawRay(transform.position, Vector3.forward, Color.blue);

    }
    protected void DisableHitBox()
    {
        if (GetComponent<PolygonCollider2D>() != null)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void UpdateLife()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoveProjectile()
    {
        // transform.right = target - transform.position;
        if (target != null)
        {
            var step = projectileSpeed * Time.deltaTime; // calculate distance to move

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if (transform.position == targetPosition)
            {
                DisableHitBox();
            }

        }


    }
    //public void SetTarget(Vector3 newTarget) { target = newTarget; }
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
    //probably shouldnt use this one but could be useful for targeting specific coordinates so im leaving it in
    public Projectile(Vector3 newTarget) { targetPosition = newTarget; }
    public Projectile(GameObject newTarget) { target = newTarget; }

    public int GetDamage() { return Damage; }
    void FlipProjectile()
    {
        if (targetPosition.x > transform.position.x)
        {
            Vector3 newScale = myScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
        else
        {
            transform.localScale = myScale;
        }


    }

    public void ReducePierce()
    {
        Pierce--;
        if (Pierce <= 0)
        {
            Destroy(gameObject);
        }
    }



}

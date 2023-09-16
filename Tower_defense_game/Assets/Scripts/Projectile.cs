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

    [SerializeField] AudioClip spawnSfx;

    [SerializeField] int Pierce = 1;

    Vector3 myScale;

    void Start()
    {
        myScale = transform.localScale;
        if (spawnSfx)
        {
            AudioManager.instance.PlaySFX(spawnSfx, 0.8f);
        }
         Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }





    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        UpdateLife();

    }
    void DisableHitBox()
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
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if(transform.position == target){
                DisableHitBox();
            }
            FlipProjectile();
        }


    }
    public void SetTarget(Vector3 newTarget) { target = newTarget; }
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform.position;
    }

    public Projectile(Vector3 newTarget) { target = newTarget; }
    public Projectile(GameObject newTarget) { target = newTarget.transform.position; }

    public int GetDamage() { return Damage; }
    void FlipProjectile()
    {
        if (target.x > transform.position.x)
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

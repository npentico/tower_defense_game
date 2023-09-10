using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 2;
    float currentMoveSpeed;
    [SerializeField] float StutterOnHit = 0.2f;
    [SerializeField] int Health = 15;
    [SerializeField] int MaxHealth =15;
    bool GotHurt = false;
    [SerializeField] float ColorFlickerTime = 0.1f;
    [SerializeField] int DamageToPLayer = 1;

    [SerializeField] int GoldValue = 1;

    [SerializeField] GameObject myHealthBarCanvas;
    Animator myAnimator;
    Vector3 initialScale;
    void Awake(){
        initialScale= transform.localScale;
        myAnimator= GetComponent<Animator>();
        currentMoveSpeed = moveSpeed;
        Health = MaxHealth;
    }

    public float getMoveSpeed(){
        return currentMoveSpeed;

    }

    public Vector3 getInitialScale(){return initialScale;}

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Projectile"){
            //take damage
          
            DoDamage(other.GetComponent<Projectile>().GetDamage());
            Destroy(other.gameObject);
        }
        else if(other.tag == "Goal"){
            Debug.Log("exddddd");
            GameManager.instance.DoDamageToPlayer(DamageToPLayer);
            UiManager.instance.UpdateHealthText();
        }
    }

    void DoDamage(int dmg){
        Health -= dmg;
        myAnimator.Play("Base Layer.Orc Hurt", 0, 0f);
      //  StartCoroutine(StutterMoveSpeed());
        StartCoroutine(FlipColor());

        if(Health <= 0){
            KillUnit();
        }
    }
    void KillUnit(){
        GameManager.instance.AddGold(GoldValue);
        UiManager.instance.SetGoldText(GameManager.instance.GetGold().ToString());
        Destroy(gameObject);
    }

    public int getMaxHealth(){
        return MaxHealth;
    }

    public int GetCurrentHealth(){
        return Health;
    }

    IEnumerator StutterMoveSpeed(){
        currentMoveSpeed = 0;
        yield return new WaitForSeconds(StutterOnHit);
        currentMoveSpeed = moveSpeed;
    }
    IEnumerator FlipColor(){
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        mySprite.color = new Color(255,0,0);
        yield return new WaitForSeconds(ColorFlickerTime);
        mySprite.color = new Color(255,255,255);   
    }

    void OnMouseEnter(){
        myHealthBarCanvas.SetActive(true);
    }
    void OnMouseExit(){
        myHealthBarCanvas.SetActive(false);
    }
 public void DoDamageToPlayer(){
    GameManager.instance.DoDamageToPlayer(DamageToPLayer);
 }
}

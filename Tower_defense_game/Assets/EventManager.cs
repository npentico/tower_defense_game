using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void DamageAction(int hpChange);
    public static event DamageAction OnDamageTaken;

    public delegate void GoldChangeAction(int goldChange);

    public static event GoldChangeAction OnGoldChange;

    public static EventManager instance;

    void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
    }

    public void DealDamage(int  hpToChange){
        if(OnDamageTaken!=null){
            OnDamageTaken(hpToChange);
        }
    }

    public void ChangeGold(int goldChangeValue){
        if(OnGoldChange!=null){
            OnGoldChange(goldChangeValue);
        }
    }
    
}

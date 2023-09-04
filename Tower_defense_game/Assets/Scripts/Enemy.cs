using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 2;

    public float getMoveSpeed(){
        return moveSpeed;
    }
}

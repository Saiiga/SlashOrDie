using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected Collider2D hitbox ;
    [SerializeField] protected Rigidbody2D rigibody ;
    protected Sprite sprite ;
    protected Animator animator ;

    public abstract void OnDie();
    public abstract void OnHit();
    
}
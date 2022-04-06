using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Collider2D hitbox ;
    [SerializeField] protected Rigidbody2D rigibody ;
    [SerializeField] protected SpriteRenderer sprite ;
    [SerializeField] protected Animator animator ;

    public abstract void OnDie();
    public abstract void OnHit();
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    Collider hitbox ;
    Rigibody rigibody ;
    Sprite sprite ;
    Animator animator ;

    public abstract void OnDie();
    public abstract void OnHit();
    
}
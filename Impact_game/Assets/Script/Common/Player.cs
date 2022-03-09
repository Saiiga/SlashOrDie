
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float m_moveSpeed;
    public int m_HP;

    public override void OnDie()
    {
        animator.Play("Death");

    }
    public override void OnHit()
    {
        animator.Play("Hit");
        RemoveHP(1);
    }
    public void TryToRecognizeAttack()
    {

    }
    public void AddHP(int HP)
    {
        m_HP += HP;
    }
    public void RemoveHP(int HP)
    {
        m_HP -= HP;
    }
} 


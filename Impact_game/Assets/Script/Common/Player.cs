
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    List<Bonus> m_bonus= new List<Bonus>();
    public float m_moveSpeed;
    public int m_HP;

    public override void OnDie()
    {
        animator.Play("Death");

    }
    public override void OnHit()
    {
        animator.Play("Hit");
    }
    public void TryToRecognizeAttack()
    {

    }
    public void AddBonus(Bonus bonus)
    {
        m_bonus.Add(bonus);
    }
    public void RemoveBonus(Bonus bonus)
    {
        m_bonus.Remove(bonus);
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


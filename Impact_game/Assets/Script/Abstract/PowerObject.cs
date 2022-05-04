using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerObject : Entity
{
    [SerializeField] protected float bonusTime;

    protected abstract void Action(Player player);

    public override void OnDie()
    {
        Destroy(this);
    }

    public void SightDown()
    {
    }
    public void Shield(Player player)
    {
        int HP = player.m_HP;
        player.AddHP(1);

        //timer

        if (player.m_HP == HP +1);
             player.RemoveHP(1);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            Action(player);
            sprite.enabled = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : Entity
{
    public ProjectilType projectilType;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            player.OnHit();
            OnHit();
        }
    }

    public override void OnDie()
    {
        animator.Play("Death");
        Destroy(this);
    }

    public override void OnHit()
    {
        OnDie();
    }
}

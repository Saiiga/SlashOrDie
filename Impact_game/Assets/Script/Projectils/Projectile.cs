using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Entity
{
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            player.OnHit();
        }
    }

    public override void OnDie()
    {
     
    }

    public override void OnHit()
    {
    
    }
}

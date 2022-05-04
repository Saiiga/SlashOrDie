using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerObject : Entity
{
    [SerializeField] protected float bonusTime;
    [SerializeField] protected float speed = 2.5f;

    protected abstract void Action(Player player);

    public override void OnDie()
    {
        Destroy(this);
    }

    public void SightDown()
    {
    }

    public void Update()
    {

            rigibody.velocity = new Vector3(-speed, 0, 0);
        
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

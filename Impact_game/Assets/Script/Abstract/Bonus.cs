using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Entity
{
    float cameraSize = 1.7f;
    [SerializeField] BonusType bonusType;
    public void Action(Player player)
    {
        switch (bonusType)
        {
            case BonusType.SightDown:
                SightDown(player);
                break;
            case BonusType.SightUp:
                SightUp(player);
                break;
            case BonusType.Shild:
                Shield(player);
                break ;
               
        }

    }

    public override void OnDie()
    {

    }

    public override void OnHit()
    {

    }

    public void SightDown(Player player)
    {
        GetComponent<Camera>().orthographicSize = cameraSize - 0.4f;
        //timer
        GetComponent<Camera>().orthographicSize = cameraSize + 0.4f;
    }
    public void SightUp(Player player)
    {
        GetComponent<Camera>().orthographicSize = cameraSize + 0.4f;
        //timer
        GetComponent<Camera>().orthographicSize = cameraSize - 0.4f;
    }

    public void Shield(Player player)
    {
        int HP = player.m_HP;
        player.AddHP(1);

        //timer

        if (player.m_HP == HP +1);
             player.RemoveHP(1);
    }

}

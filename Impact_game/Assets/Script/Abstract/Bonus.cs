using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Entity
{
    float cameraSize = 1.7f;
    [SerializeField] BonusType bonusType;
    public void Action(Player player)
    {
      
            
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

    public void Shild(Player player)
    {

    }

}

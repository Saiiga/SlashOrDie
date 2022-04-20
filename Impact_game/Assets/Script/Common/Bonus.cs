using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Entity
{
    float cameraSize = 1.7f;
    [SerializeField] BonusType bonusType;
    [SerializeField] float bonusTime;
    [SerializeField] float bonusSightEffect;
    public void Action(Player player)
    {
        switch (bonusType)
        {
            case BonusType.SightDown:
                SightDown();
                break;
            case BonusType.SightUp:
                SightUp();
                break;
            case BonusType.Shield:
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

    public void SightDown()
    {
        StartCoroutine(BonusSightDownCoroutine(1 - bonusSightEffect));
    }
    public void SightUp()
    {
        StartCoroutine(BonusSightUpCoroutine(1 + bonusSightEffect));

    }

    IEnumerator BonusSightUpCoroutine(float zoomFactor)
    {
        Camera camera = Camera.current;
        camera.orthographicSize = camera.orthographicSize * zoomFactor;
        yield return new WaitForSeconds(bonusTime);
        camera.orthographicSize = camera.orthographicSize / zoomFactor;
    }

    IEnumerator BonusSightDownCoroutine(float zoomFactor)
    {
        Camera camera = Camera.current;
        camera.orthographicSize = camera.orthographicSize * zoomFactor;
        camera.transform.position = new Vector2(camera.transform.position.x, camera.transform.position.y * 0.9f);
        yield return new WaitForSeconds(bonusTime);
        /*camera.orthographicSize = camera.orthographicSize / zoomFactor;
        camera.transform.position = new Vector2(camera.transform.position.x, camera.transform.position.y / 0.9f);
*/
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
        }
    }

}
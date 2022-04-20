using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerObject : Entity
{
    protected bool isActivated;
    [SerializeField] protected float bonusTime;

    protected abstract void Action(Player player);

    public override void OnDie()
    {
        Destroy(this);
    }

    public void SightDown()
    {
    }

    IEnumerator BonusSightDownCoroutine(float zoomFactor)
    {
        Camera camera = Camera.main;
        Debug.Log("size : " + camera.orthographicSize);
        camera.orthographicSize = camera.orthographicSize * zoomFactor;
        Debug.Log("size 2 : " + camera.orthographicSize);

        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y * 0.9f, camera.transform.position.z);
        yield return new WaitForSeconds(bonusTime);
        /*camera.orthographicSize = camera.orthographicSize / zoomFactor;
         *         Debug.Log("size 3: " + camera.orthographicSize);

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

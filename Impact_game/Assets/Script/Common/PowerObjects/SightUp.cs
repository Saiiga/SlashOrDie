using System.Collections;
using UnityEngine;

public class SightUp : PowerObject
{
    [SerializeField] float bonusSightEffect;
    [SerializeField] float speedEffect;
    private float initialZoom;
    private float targetZoom;
    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }

    protected override void Action(Player player)
    {
        StartCoroutine(BonusSightUpCoroutine());
        isActivated = true;
    }

    public void Start()
    {
        initialZoom = Camera.main.orthographicSize;
        targetZoom = Camera.main.orthographicSize * (1 + bonusSightEffect);
    }

    public void Update()
    {
    }

    IEnumerator BonusSightUpCoroutine()
    {
        Camera.main.orthographicSize = targetZoom;
        //camera.orthographicSize = camera.orthographicSize * zoomFactor;
        yield return new WaitForSeconds(bonusTime);
        //camera.orthographicSize = camera.orthographicSize / zoomFactor;
        Camera.main.orthographicSize = initialZoom;

    }

}

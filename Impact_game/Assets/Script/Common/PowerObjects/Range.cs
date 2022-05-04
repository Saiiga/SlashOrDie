using System.Collections;
using UnityEngine;

public class Range : PowerObject
{
    [SerializeField] float offset;
    GameObject marker;
    public override void OnHit()
    {
    }

    protected override void Action(Player player)
    {
        StartCoroutine(RangeCoroutine());
    }

    // Use this for initialization
    void Start()
    {
        marker = GameObject.Find("AttackIndicator");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RangeCoroutine()
    {
        marker.transform.position += new Vector3(offset, 0) ;
        GameController.pointAttackAvailable = marker.transform.position.x;
        yield return new WaitForSeconds(bonusTime);
        marker.transform.position -= new Vector3(offset, 0);
        GameController.pointAttackAvailable = marker.transform.position.x;
    }
}

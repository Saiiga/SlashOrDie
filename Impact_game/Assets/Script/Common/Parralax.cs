using System.Collections;
using UnityEngine;

public class Parralax : MonoBehaviour
{

    [SerializeField]private float moveSpeed = 1f;

    [SerializeField] private float offset;

    private Vector2 startPostion;
    private float newXposition;

    // Use this for initialization
    void Start()
    {
        startPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPostion + Vector2.right * newXposition;
    }
}

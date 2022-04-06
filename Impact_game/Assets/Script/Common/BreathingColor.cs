using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteToTarget;
    [SerializeField] private Color originColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private float tempo;
    private float lerptTempo = 0;

    // Update is called once per frame
    void Update()
    {
        spriteToTarget.color = Color.Lerp(targetColor, originColor, Mathf.PingPong(Time.fixedTime, tempo));

    }
}

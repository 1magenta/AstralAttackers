using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PulseEffect : MonoBehaviour
{
    public float pulseSpeed = 1.0f;
    public float pulseAmount = 0.5f;
    private Renderer rend;
    private Color originalColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void Update()
    {
        float sinWave = (Mathf.Sin(Time.time * pulseSpeed) + 1) / 2;
        rend.material.color = Color.Lerp(originalColor, originalColor + new Color(pulseAmount, pulseAmount, pulseAmount), sinWave);
    }
}

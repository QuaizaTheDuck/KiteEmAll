using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBEffect : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float colorSpeed = 1f;
    private Color currentColor;

    void Start()
    {
        currentColor = image.color;
    }

    void Update()
    {
        float r = Mathf.Sin(Time.time * colorSpeed) * 0.5f + 0.5f;
        float g = Mathf.Sin(Time.time * colorSpeed + Mathf.PI * 2f / 3f) * 0.5f + 0.5f;
        float b = Mathf.Sin(Time.time * colorSpeed + Mathf.PI * 4f / 3f) * 0.5f + 0.5f;

        currentColor.r = r;
        currentColor.g = g;
        currentColor.b = b;

        image.color = currentColor;
    }
}

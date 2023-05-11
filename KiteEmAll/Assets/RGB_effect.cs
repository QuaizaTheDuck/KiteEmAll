using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB_effect : MonoBehaviour
{
    private Color originalColor;
    [SerializeField] private float colorSpeed = 1f;
    private Color currentColor;
    public void activateRGB(float duration)
    {
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        currentColor = originalColor;
        StartCoroutine(RainbowColorEffect(gameObject.GetComponent<SpriteRenderer>(), duration));
    }
    private IEnumerator RainbowColorEffect(SpriteRenderer sprite, float duration)
    {
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float r = Mathf.Sin(Time.time * colorSpeed) * 0.5f + 0.5f;
            float g = Mathf.Sin(Time.time * colorSpeed + Mathf.PI * 2f / 3f) * 0.5f + 0.5f;
            float b = Mathf.Sin(Time.time * colorSpeed + Mathf.PI * 4f / 3f) * 0.5f + 0.5f;

            currentColor.r = r;
            currentColor.g = g;
            currentColor.b = b;

            sprite.color = currentColor;
            yield return null;
        }

        // Return to the original color after the effect is done
        sprite.color = originalColor;
    }


}
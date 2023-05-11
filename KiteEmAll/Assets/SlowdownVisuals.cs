using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownVisuals : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float opacitySpeed = 1f;
    public float lifespan = 5f;
    private float timer = 0f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        timer += Time.deltaTime;

        float alpha;
        if (timer < 1f)
        {
            alpha = Mathf.Lerp(0f, 1f, timer);
        }
        else if (timer >= 4f)
        {
            alpha = Mathf.Lerp(1f, 0f, (timer - 4f) / 1f);
        }
        else
        {
            alpha = 1f;
        }
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = alpha;
        GetComponent<SpriteRenderer>().color = color;

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}

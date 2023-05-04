using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f;
    public Text fpsText;

    private float accum = 0f;
    private int frames = 0;
    private float timeLeft;

    private void Start()
    {
        timeLeft = updateInterval;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;

        if (timeLeft <= 0f)
        {
            float fps = accum / frames;
            string fpsString = string.Format("{0:F2} FPS", fps);
            fpsText.text = fpsString;

            timeLeft = updateInterval;
            accum = 0f;
            frames = 0;
        }
    }
}

using UnityEngine;

public class DestroyAfterDuration : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        Destroy(gameObject, particleSystem.main.duration);
    }
}

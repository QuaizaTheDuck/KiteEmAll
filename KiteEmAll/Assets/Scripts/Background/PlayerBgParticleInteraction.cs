using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBgParticleInteraction : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.Particle[] particles;
    public Rigidbody2D rbPlayer;
    public float rotationSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 anglesToRotate = new Vector3(0, 0, 0);
        Vector2 RbPlayerVelocityNormalize = rbPlayer.velocity.normalized;
        anglesToRotate.x = RbPlayerVelocityNormalize.y;
        anglesToRotate.y = RbPlayerVelocityNormalize.x;
        ps.transform.Rotate(anglesToRotate * rotationSpeed * Time.deltaTime);
        //ps.transform.rotation = Quaternion.Euler(ps.transform.rotation.x + rbPlayer.velocity.x, ps.transform.rotation.x + rbPlayer.velocity.x, 0);
    }
}

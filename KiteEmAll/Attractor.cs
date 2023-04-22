using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{



    public Rigidbody2D rb;
    public Rigidbody2D rbToAttract;
    public float attractRange;
    public float forceMagnitude = 4;

    void FixedUpdate()
    {
        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance <= attractRange)
            Attract(rbToAttract, direction);
        else
            return;
    }


    void Attract(Rigidbody2D rbToAttract, Vector2 direction)
    {

        Vector2 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }

}
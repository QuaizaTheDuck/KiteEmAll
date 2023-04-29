using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : DefaultEnemy
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
}

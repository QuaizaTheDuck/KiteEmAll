using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : ActiveAbility
{
    private GameObject player = null;
    private PlayerStats playerStats;
    [SerializeField] private GameObject slowdownVisuals;
    [SerializeField] private LayerMask layerMask;
    private Collider2D[] colliders;
    public override void Activate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        playerStats = player.GetComponent<PlayerStats>();

        Instantiate(slowdownVisuals, player.transform.position, Quaternion.identity);

        colliders = Physics2D.OverlapCircleAll(player.transform.position, 8 * playerStats.areaOfEffectMulti.Value, layerMask);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<Rigidbody2D>().drag = 100;
        }

    }

    public override void DeActivate()
    {
        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.GetComponent<Rigidbody2D>() != null)
                collider.GetComponent<Rigidbody2D>().drag = 0;
        }
    }
}

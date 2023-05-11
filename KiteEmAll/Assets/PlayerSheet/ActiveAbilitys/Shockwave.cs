using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shockwave : ActiveAbility
{
    private GameObject player = null;
    private PlayerStats playerStats;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject shockwaveprefab;
    public override void Activate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        playerStats = player.GetComponent<PlayerStats>();

        // Get the ParticleSystem component of the shockwaveprefab
        GameObject shockwaveObject = Instantiate(shockwaveprefab, player.transform.position, Quaternion.identity);
        ParticleSystem shockwavePS = shockwaveObject.GetComponent<ParticleSystem>();
        shockwavePS.startSize = (8 * playerStats.areaOfEffectMulti.Value) + 4;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, 5 * playerStats.areaOfEffectMulti.Value, layerMask);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<EnemyBase>().TakeDamage(100 * playerStats.weaponDamageMulti.Value);
        }


    }

    public override void DeActivate()
    {

    }
}



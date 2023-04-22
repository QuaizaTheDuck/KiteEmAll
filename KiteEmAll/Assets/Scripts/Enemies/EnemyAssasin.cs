using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssasin : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameObject;
    PlayerStats targetPlayerStats;
    [SerializeField] float movementSpeed;
    [SerializeField] int hp = 10;
    [SerializeField] int damage = 5;
    [SerializeField] float attackRate = 0.5f;
    private float timer = 0;

    Rigidbody2D rbEnemy;
    //Asssasin > jednak shield guy
    private GameObject[] playerWeapon;
    private GameObject closestPlayerWeapon;
    private int shieldDurability = 3;
    private float shieldCD = 7;
    private bool isShieldActive = true;
    private float shieldTimer;

    private GameObject findClosestPlayerWeapon()
    {
        playerWeapon = GameObject.FindGameObjectsWithTag("PlayerWeapon");
        GameObject closest = playerWeapon[0];
        foreach (GameObject item in playerWeapon)
        {
            if ((item.transform.position - rbEnemy.transform.position).magnitude < (closest.transform.position - rbEnemy.transform.position).magnitude)
                closest = item;

        }
        return closest;
    }
    private void Awake()
    {
        shieldTimer = shieldCD;
        rbEnemy = GetComponent<Rigidbody2D>();
        //targetGameObject = targetDestination.gameObject;
    }

    public void SetTrarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {

        if (shieldDurability >= 0)
        {
            closestPlayerWeapon = findClosestPlayerWeapon();
            if ((closestPlayerWeapon.transform.position - rbEnemy.transform.position).magnitude < 2)
            {
                Destroy(closestPlayerWeapon);
                shieldDurability--;
            }
        }
        else
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer < 0)
            {
                shieldDurability = 3;
                shieldTimer = shieldCD;
            }
        }
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rbEnemy.velocity = direction * movementSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            timer += Time.deltaTime;
            if (timer > attackRate)
                Attack();
        }
    }
    void Attack()
    {
        //Debug.Log("Enemy attacks player");
        if (targetPlayerStats == null)
        {
            targetPlayerStats = targetGameObject.GetComponent<PlayerStats>();
        }
        targetPlayerStats.PlayerTakeDamage(damage);
        timer = 0;
    }

    public void EnemyTakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
            Destroy(gameObject);
    }
}

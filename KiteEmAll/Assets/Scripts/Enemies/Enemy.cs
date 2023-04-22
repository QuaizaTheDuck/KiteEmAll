using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    private void Awake()
    {
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

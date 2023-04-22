using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarragerHoming : MonoBehaviour
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

    //Shooter
    [SerializeField] float shootRate = 4f;
    [SerializeField] float shootingRange = 7;
    private float shootingTimer;
    [SerializeField] GameObject enemyBullet;
    private Vector3 direction;
    private void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        shootingTimer = shootRate / 2;
        //targetGameObject = targetDestination.gameObject;
    }

    public void SetTrarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        direction = (targetDestination.position - transform.position).normalized;
        rbEnemy.velocity = direction * movementSpeed;
        if ((targetDestination.position - transform.position).magnitude < shootingRange)
            Shoot();
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

    void Shoot()
    {
        shootingTimer += Time.deltaTime;
        if (shootingTimer > shootRate)
        {
            for (int i = -1; i <= 1; i++)
            {
                Debug.Log(i);
                if (i == 0)
                    continue;
                GameObject firedEnemyBullet = Instantiate(enemyBullet);
                firedEnemyBullet.transform.position = transform.position;
                firedEnemyBullet.GetComponent<EnemyBulletHoming>().SetTrarget(targetGameObject);
                float fireAngle = 30 * i;
                Vector3 rotatedDirection = Quaternion.Euler(0f, 0f, fireAngle) * direction;
                firedEnemyBullet.GetComponent<EnemyBulletHoming>().setDirection(rotatedDirection);
            }
            shootingTimer = 0;
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
            Destroy(gameObject);
    }
}

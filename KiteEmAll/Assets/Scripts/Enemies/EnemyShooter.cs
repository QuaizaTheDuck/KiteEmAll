using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
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
    [SerializeField] float shootRate = 1f;
    private bool isShooting = false;
    [SerializeField] float shootingRange = 5;
    private float shootingTimer = 0;
    [SerializeField] GameObject enemyBullet;
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
        if ((targetDestination.position - transform.position).magnitude > shootingRange && !isShooting)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            rbEnemy.velocity = direction * movementSpeed;
            return;
        }
        rbEnemy.velocity = rbEnemy.velocity * 0;
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
        isShooting = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        shootingTimer += Time.deltaTime;
        if (shootingTimer > shootRate)
        {
            GameObject firedEnemyBullet = Instantiate(enemyBullet);
            firedEnemyBullet.transform.position = transform.position;
            firedEnemyBullet.GetComponent<EnemyBullet>().setDirection(new Vector2((targetDestination.position.x - transform.position.x), (targetDestination.position.y - transform.position.y)));
            shootingTimer = 0;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            isShooting = false;
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
            Destroy(gameObject);
    }
}

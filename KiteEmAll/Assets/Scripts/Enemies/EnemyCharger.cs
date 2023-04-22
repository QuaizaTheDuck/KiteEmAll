using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : MonoBehaviour
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

    //Charger Stats
    //czas ładowania szarzy
    private float chargeChannelTime = 1;
    //czas trwania szarzy
    private float chargeTime = 2;
    private float chargeTimer = 0;
    private float chargeRange = 5;
    private bool isCharging = false;
    private bool isReadyToAttack = false;
    private Vector3 direction;

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
        if ((targetDestination.position - transform.position).magnitude > chargeRange && !isCharging)
        {
            direction = (targetDestination.position - transform.position).normalized;
            rbEnemy.velocity = direction * movementSpeed;
            return;
        }
        charge();
    }
    private void charge()
    {
        //ma insta zaatakowac on kontakt
        if (isCharging == false)
            isReadyToAttack = true;

        isCharging = true;
        chargeTimer += Time.deltaTime;

        //w czasie ladowania 
        if (chargeTimer < chargeChannelTime)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            direction = (targetDestination.position - transform.position).normalized;
            rbEnemy.velocity = direction * movementSpeed / 4;
            return;
        }
        //w czasie szarzy, i dalego od gracza
        if (chargeTimer < chargeTime + chargeChannelTime && chargeTimer > chargeChannelTime && (targetDestination.position - transform.position).magnitude > chargeRange * 2)
        {
            isCharging = false;
            chargeTimer = 0;
            isReadyToAttack = false;
            return;
        }
        //w czasie szarzy
        if (chargeTimer < chargeTime + chargeChannelTime && chargeTimer > chargeChannelTime)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            rbEnemy.velocity = direction * movementSpeed * 3;
            return;
        }
        //po wykonanej szarzy
        if (chargeTimer > chargeTime + chargeChannelTime)
        {
            isCharging = false;
            chargeTimer = 0;
            isReadyToAttack = false;
            return;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            if (isReadyToAttack)
            {
                Attack();
                isReadyToAttack = false;
            }
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

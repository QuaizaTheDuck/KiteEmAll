using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodger : MonoBehaviour
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
    //Dodger
    private GameObject[] playerWeapon;
    private GameObject closestPlayerWeapon;
    private float dodgeCD = 0.5f;
    private float dodgeTimerCD;
    private float dodgeTime = 0.2f;
    private float dodgeTimer;
    private bool isDodging;
    float dodgeAngle;

    private void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        //targetGameObject = targetDestination.gameObject;
    }

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


    public void SetTrarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (!isDodging)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            rbEnemy.velocity = direction * movementSpeed;

            dodgeTimerCD -= Time.deltaTime;
            if (dodgeTimerCD < 0)//dodge is ready
            {
                closestPlayerWeapon = findClosestPlayerWeapon();
                //pocisk znalazł się wystarczająco blisko zacząć dodge
                if ((closestPlayerWeapon.transform.position - rbEnemy.transform.position).magnitude < 2)
                {
                    if (!isDodging)
                        dodgeAngle = Random.Range(-1f, 1f);
                    isDodging = true;
                }
            }
        }
        else
        {
            //jeśli wykryto pocisk w zasiegu zmieniamy patern ruchu na dodge
            //czas trwania dodge 
            dodgeTimer -= Time.deltaTime;
            closestPlayerWeapon = findClosestPlayerWeapon();

            if (dodgeAngle < 0)
            {
                Vector3 direction = (targetDestination.position - transform.position).normalized;
                Vector3 rotatedDirection = Quaternion.Euler(0f, 0f, -90) * direction;
                rbEnemy.velocity = rotatedDirection * movementSpeed * 5;
            }
            if (dodgeAngle >= 0)
            {
                Vector3 direction = (targetDestination.position - transform.position).normalized;
                Vector3 rotatedDirection = Quaternion.Euler(0f, 0f, 90) * direction;
                rbEnemy.velocity = rotatedDirection * movementSpeed * 5;
            }

            //jesli dodge sie skonczyl
            if (dodgeTimer < 0)
            {
                isDodging = false;
                dodgeTimerCD = dodgeCD;
                dodgeTimer = dodgeTime;
            }
        }





        /* if (dodgeTimerCD <= 0)
        {
            closestPlayerWeapon = findClosestPlayerWeapon();
            if ((closestPlayerWeapon.transform.position - rbEnemy.transform.position).magnitude < 2)
            {
                if (!isDodging)
                {
                    dodgeAngle = Random.Range(-1f, 1f);
                    Debug.Log(dodgeAngle);
                }
                isDodging = true;
                if (dodgeAngle < 0)
                {

                    Vector3 direction = (targetDestination.position - transform.position).normalized;
                    Vector3 rotatedDirection = Quaternion.Euler(0f, 0f, -90) * direction;
                    Debug.DrawRay(rbEnemy.transform.position, direction * movementSpeed, Color.red);
                    rbEnemy.velocity = direction * movementSpeed;
                    dodgeTimer -= Time.deltaTime;
                    if (dodgeTimer < 0)
                    {
                        isDodging = false;
                        dodgeTimer = dodgeTime;
                        dodgeTimerCD = dodgeCD;
                    }
                }
                if (dodgeAngle > 0)
                {

                    Vector3 direction = (targetDestination.position - transform.position).normalized;
                    Vector3 rotatedDirection = Quaternion.Euler(0f, 0f, 90) * direction;
                    Debug.DrawRay(rbEnemy.transform.position, direction * movementSpeed, Color.red);
                    rbEnemy.velocity = direction * movementSpeed;
                    dodgeTimer -= Time.deltaTime;
                    if (dodgeTimer < 0)
                    {
                        isDodging = false;
                        dodgeTimer = dodgeTime;
                        dodgeTimerCD = dodgeCD;
                    }
                }

            }
        } */


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

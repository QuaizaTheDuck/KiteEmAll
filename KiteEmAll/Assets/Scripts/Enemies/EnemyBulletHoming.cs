using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHoming : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] int damage;
    [SerializeField] float startingProjectileSpeed = 4;
    [SerializeField] float finalProjectileSpeed = 10;
    private float currentProjectileSpeed;


    [SerializeField] float projectileLifeTime = 5;
    private float timer = 0;
    //Homing
    GameObject targetGameObject;
    Vector3 lastHomingDirection;
    private void Awake()
    {
        currentProjectileSpeed = startingProjectileSpeed;
    }
    public void SetTrarget(GameObject target)
    {
        targetGameObject = target;
    }

    public void setDirection(Vector2 aimDirection)
    {

        direction = aimDirection.normalized;
    }

    // Update is called once per frame

    bool hitDetected = false;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > projectileLifeTime)
            Destroy(gameObject);

        if (Vector2.Angle(direction, (targetGameObject.transform.position - transform.position)) < 90)
        {
            lastHomingDirection = (direction + (targetGameObject.transform.position - transform.position).normalized / 2);
            transform.position += lastHomingDirection * currentProjectileSpeed * Time.deltaTime;

        }
        else
            transform.position += lastHomingDirection * currentProjectileSpeed * Time.deltaTime;
        /* Debug.DrawRay(transform.position, direction * 5, Color.blue);
        Debug.DrawRay(transform.position, (targetGameObject.transform.position - transform.position).normalized * 5, Color.red);
 */
        if (timer < 2 * projectileLifeTime / 3)
        {
            currentProjectileSpeed = startingProjectileSpeed + ((finalProjectileSpeed - startingProjectileSpeed) * (timer / (2 * projectileLifeTime / 3)));
        }



        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D c in hit)
        {
            PlayerStats player = c.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.PlayerTakeDamage(damage);
                Destroy(gameObject);
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] int damage;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float projectileLifeTime = 2;
    private float timer = 0;

    public void setDirection(Vector2 aimDirection)
    {

        direction = aimDirection.normalized;
    }

    // Update is called once per frame

    bool hitDetected = false;
    void Update()
    {

        timer += Time.deltaTime;
        Debug.Log(direction);
        transform.position += direction * projectileSpeed * Time.deltaTime;

        if (timer > projectileLifeTime)
            Destroy(gameObject);

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

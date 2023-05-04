using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float expDroped;
    protected float currentHealth;
    protected Transform target;
    protected float statMulti;
    protected bool isStatMultiApplied = false;
    protected Rigidbody2D enemyRb;
    [SerializeField] GameObject ExpGem;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }
    virtual protected void Update()
    {
        if ((target.position - transform.position).magnitude > 40)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f); // Random angle around the circle
            Vector3 spawnPosition = new Vector3(Mathf.Sin(angle) * 25f, Mathf.Cos(angle) * 25f, 0f); // Calculate position on the circle
            spawnPosition += target.position;
            transform.position = spawnPosition;

            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            transform.rotation = randomRotation;
        }
    }
    public void SetTargetAndStatMulti(Transform target, float statMulti)
    {
        this.target = target;
        this.statMulti = statMulti;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Implement enemy death logic here

        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        GameObject spawnedGem = Instantiate(ExpGem, transform.position, Quaternion.identity);
        spawnedGem.GetComponent<ExpGem>().setExpGranted(expDroped);

    }
}

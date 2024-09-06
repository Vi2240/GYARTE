using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] float maxHealth;
    [SerializeField] float attackRange;

    [SerializeField] GameObject tower;

    float currentHealth;
    bool inAttackingRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(tower != null)
        {
            MoveToTarget();
        }
        else
        {
            Debug.Log("no target");
        }
    }

    void MoveToTarget()
    {
        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, tower.transform.position);

        // Check if the enemy is within attack range
        if (distanceToTarget > attackRange)
        {
            // Calculate the direction from the enemy to the target
            Vector3 direction = tower.transform.position - transform.position;
            direction.Normalize();

            // Move the enemy towards the target
            transform.position += direction * enemySpeed * Time.deltaTime;

            inAttackingRange = false;
        }
        else
        {
            inAttackingRange = true;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //Dead
        }
    }
}

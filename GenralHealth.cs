using UnityEngine;

public class GenralHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject prefabToSpawn = null;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        if (currentHealth <= 0)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y *25, transform.position.z);
            Instantiate(prefabToSpawn, newPosition, transform.rotation);
            Die();
        }
    }

    void Die()
    {
        // Play death animation or sound
        Destroy(gameObject);
    }
}

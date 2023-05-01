using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int healthAmount = 100;
    public float delayTime = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.Heal(healthAmount);
            print("Healed! Health is now " + player.health);

            // Delay the destruction of the health object
            Invoke("DestroyObject", delayTime);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
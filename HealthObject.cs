using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int healthAmount = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player

            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}

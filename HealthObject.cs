using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int healthAmount = 100;
    public float pickupDelay = 2f; // delay in seconds before the object can be picked up
    private bool canBePickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canBePickedUp)
        {
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.Heal(healthAmount);
            print("Healed! Health is now " + player.currentHealth);
            // Destroy the HealthObject
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Invoke("EnablePickup", pickupDelay);
    }

    private void EnablePickup()
    {
        canBePickedUp = true;
    }
}

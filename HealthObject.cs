using UnityEngine;
using System.Collections;

public class HealthObject : MonoBehaviour
{
    public int healAmount = 100;
    private void OnTriggerEnter(Collider other)
    {
        private bool hasGivenHealth = false;
        public float Delay = 2f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !hasGivenHealth)
            {
                // Get the PlayerController component from the player
                PlayerController playerController = other.GetComponent<PlayerController>();

                // Heal the player and set hasGivenHealth to true
                playerController.Heal(healAmount);
                hasGivenHealth = true;

                // Wait for 5 seconds before destroying the object
                Invoke("Destroy(gameObject);", Delay);   
            
            }
        }

       
    }
}
using UnityEngine;

public class RingOfSwift : MonoBehaviour
{

    public string Ring  = "RingOfSwift";
    public float modification = 1.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.moveSpeed *= modification;
            player.attackCooldown /= modification;
            // Destroy the battle axe object
            Destroy(transform.parent.gameObject);
        }
    }
}

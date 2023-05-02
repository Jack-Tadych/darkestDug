using UnityEngine;

public class RingOfReach : MonoBehaviour
{

    public string Ring = "RingOfReach";
    public float modification = 1.5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.attackRange *= modification;
            
            // Destroy the battle axe object
            Destroy(transform.parent.gameObject);
        }
    }
}


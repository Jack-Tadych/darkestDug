using UnityEngine;

public class RingOfKevin : MonoBehaviour
{

    public string Ring = "RingOfKevin";
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.ringOfKevin = true;
            
            // Destroy the battle axe object
            Destroy(transform.parent.gameObject);
        }
    }
}

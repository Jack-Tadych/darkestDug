using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int healAmount = 100;
    public float pickupDelay = 1.0f; // 
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Heal(healAmount);

            canBePickedUp = false;
            StartCoroutine(StartPickupDelay());
    }
    

    private IEnumerator StartPickupDelay()
    {
        yield return new WaitForSeconds(pickupDelay);
        canBePickedUp = true;
        Destroy(gameObject);
    }

}
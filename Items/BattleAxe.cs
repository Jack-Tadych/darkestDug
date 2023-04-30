using UnityEngine;

public class BattleAxe : MonoBehaviour
{

    public string weapon = "BattleAxe";
    public float newAttackRange = 3f;
    public int newAttackDamage = 75;
    public float newAttackCooldown = 5f;
    public float moveSpeed = 3f;
    public int health = 400;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.attackRange = newAttackRange;
            player.attackDamage = newAttackDamage;
            player.attackCooldown = newAttackCooldown;
            player.moveSpeed = moveSpeed;
            player.weapon = weapon;
            player.health = health;


            // Destroy the battle axe object
            Destroy(transform.parent.gameObject);

        }
    }
}

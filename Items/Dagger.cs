using UnityEngine;

public class Dagger : MonoBehaviour
{
    

    public string weapon = "dagger";
    public float newAttackRange = 1f;
    public int newAttackDamage = 2;
    public float newAttackCooldown = .5f;
    public float moveSpeed = 3f;
    public int health = 1;

    public void pickUp()
    {
        
            
            // Get the PlayerController component from the player
            GameObject playerObject = GameObject.FindWithTag("Player");
            PlayerController player = playerObject.GetComponent<PlayerController>();


            // Change the values of the variables in the PlayerController script
            player.attackRange *= newAttackRange;
            player.attackDamage *= newAttackDamage;
            player.attackCooldown *= newAttackCooldown;
            player.moveSpeed *= moveSpeed;
            player.weapon = weapon;
            player.maxHealth *= health;

            // Destroy the battle axe object
            Destroy(transform.parent.gameObject);

        
    }
}

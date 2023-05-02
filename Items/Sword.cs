using UnityEngine;

public class Sword : MonoBehaviour
{

    public string weapon = "sword";
    public float newAttackRange = 2.5f;
    public int newAttackDamage = 3;
    public float newAttackCooldown = 1.25f;
    public float moveSpeed =  1.75f;
    public int health =  2;

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

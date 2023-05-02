using UnityEngine;

public class BattleAxe : MonoBehaviour
{

    public string weapon = "BattleAxe";
    public float newAttackRange = 4f;
    public int newAttackDamage = 4;
    public float newAttackCooldown = 2f;
    public float moveSpeed = .5f;
    public int health = 4;

     public void pickUp()
    {
        
            
            // Get the PlayerController component from the player
            GameObject playerObject = GameObject.FindWithTag("Player");
            PlayerController player = playerObject.GetComponent<PlayerController>();

            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.attackRange *= newAttackRange;
            player.attackDamage *= newAttackDamage;
            player.attackCooldown *= newAttackCooldown;
            player.moveSpeed *= moveSpeed;
            player.weapon = weapon;
            player.maxHealth *= health;

            //change the wepon stats above to multipy the players base stats

            // Destroy the battle axe object
            Destroy(transform.parent.gameObject);

        }
    }
}

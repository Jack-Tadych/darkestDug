using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public AudioSource basic_swing;

    public string weapon = "fists";
    public string died;
    public Slider healthBar;


    //string[] myArray = new string[5];


    public float moveSpeed = 5f;
    public float turnSpeed = 30f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    public float healFactor = 1f;
    public int attackDamage = 50;

    public int maxHealth = 100;
    public int currentHealth = 1;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;
    
    

    public GameObject glowstick = null;
    
   

    void Start()
    {
        basic_swing = GetComponent<AudioSource>();
        weapon = "fists";
        currentHealth = maxHealth;
    }

    public void Heal(int healAmount)
    {
        if(healAmount+currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }else{
        healAmount = (int)(healAmount * healFactor);
        currentHealth += healAmount;
        }
       
    
        print("Healed! currentHealth is now " + currentHealth);
    }

    private void healBar(){
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print("Ouch! currentHealth is now " + currentHealth);
       
        if (currentHealth <= 0)
        {
            // Die
            print("You died!");
            SceneManager.LoadScene(died);
        }

    }

    void Update()
    {
        //camera 
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        // Get input from arrow keys or joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         // Rotate player based on horizontal input
        transform.Rotate(0f, horizontalInput * turnSpeed * Time.deltaTime, 0f);

        // Move player forward or backward based on vertical input
        Vector3 direction = transform.forward * verticalInput;
        transform.position += direction * moveSpeed * Time.deltaTime;



        AttackV2();
        click();
        drop();
        healBar();
    }


    void click() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked on object with tag: " + hit.collider.gameObject.tag);
            }
        }
        
        
    }
    void drop()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(glowstick, transform.position, transform.rotation);
        }
    }
    void AttackV2()
    {
        // Attack
        if (!isAttacking && Time.time - lastAttackTime > attackCooldown && Input.GetKeyDown(KeyCode.F))
        {
            // Play attack animation

            // Play attack sound
            basic_swing.Play();
            // Set isAttacking flag to true and save the time of the attack
            isAttacking = true;
            lastAttackTime = Time.time;

            // Get all colliders within range of the attack
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

            // Loop through all colliders and apply damage to enemies
            foreach (Collider hitCollider in hitColliders)
            {
                string colliderTag = hitCollider.tag;

                // Check if the collider belongs to an enemy
                if (colliderTag == "Enemy")
                {
                    // Apply damage to the enemy
                    GenralHealth enemy = hitCollider.GetComponent<GenralHealth>();                    enemy.TakeDamage(attackDamage);
                }
            }
        }


        // Reset isAttacking flag after attackCooldown time
        if (isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            isAttacking = false;
        }
    


    }

    // Not relvent anymore
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Get all colliders within range of the attack
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

            // Loop through all colliders and apply damage to enemies
            foreach (Collider hitCollider in hitColliders)
            {

                string colliderTag = hitCollider.tag;

                // Check if the collider belongs to an enemy
                if (colliderTag == "Enemy")
                {
                    // Apply damage to the enemy
                    GenralHealth enemy = hitCollider.GetComponent<GenralHealth>();
                    enemy.TakeDamage(attackDamage);
                }
                
                
            }
        }

    }
    // Draw a sphere around the player to show the range of the attack
    //It doesn't work I don't know why
    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere around the player to show the range of the attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}



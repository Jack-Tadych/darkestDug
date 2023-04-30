using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyAI : MonoBehaviour
{
    Animator anim;
    private GameObject player = null;
    public NavMeshAgent agent;
    public Vector3 velocity;

    //attack/
    public float attackRange = 2f;
    public int attackDamage = 50;
    public float attackCooldown = 5f;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;
    public float Delay = 2f;

    private bool isTouchingPlayer = false;

    void AttackV2()
    {
        anim.SetTrigger("Attack");
        Invoke("hittingThePlayer", Delay);   
    }
    private void hittingThePlayer()
    {
        // Attack
        if (!isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            // Play attack animation

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
                if (colliderTag == "Player")
                {
                    // Apply damage to the enemy
                    PlayerController Player = hitCollider.GetComponent<PlayerController>();
                    Player.TakeDamage(attackDamage);
                }
            }
        }


        // Reset isAttacking flag after attackCooldown time
        if (isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            isAttacking = false;
        }



    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Found player - " + player);
        }
        /** Put the enemy on the closest NavMesh. 
         * Note that this will move the enemy's position. 
         * If you don't want to let the script the position of enemy, comment out this block.*/
        
        NavMeshHit closestHit;
        if (NavMesh.SamplePosition(this.transform.position, out closestHit, 500, 1))
        {
            //Place the object to the NavMesh.
            this.transform.position = closestHit.position;
        }

        //setup agent if not assigned
        if (agent == null)
        {
            //If the object does not have NavMeshAgent component, add one
            if (this.gameObject.GetComponent<NavMeshAgent>() == null)
            {
                this.gameObject.AddComponent<NavMeshAgent>();
                Debug.Log("NavMeshAgent component added by script");
            }
            else
                Debug.Log("Using its existing NavMeshAgent component");

            //assign its own NavMeshAgent to agent
            agent = this.GetComponent<NavMeshAgent>();
            Debug.Log("Agent set to its own NavMeshAgent component");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            AttackV2();
            isTouchingPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isTouchingPlayer = false;
        }
    }
    public void Update() {
        print("FUCKINIG HELPP");
        print(isTouchingPlayer);

        if(isAttacking != null && isTouchingPlayer == True){
            anim.SetTrigger("Idle");
        }
        else if (isAttacking != null && isTouchingPlayer == False) 
        {
            agent.destination = player.transform.position;
            anim.SetTrigger("Move");
        }

        //velocity = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeMovement : MonoBehaviour
{
    // Variables
    public Transform playerPosition;   // position of player
    private float withinRange;    // within range of player position to chase
    public float speedMovement;    // enemy speed
    //private float offSetPosition;    // offset position of enemy to player position .. as to not be on top of player to be able to attack 

    private Vector3 destination;    // destination of target
    NavMeshAgent agent;   // component of navmeshagent

    private Rigidbody rb;   // Enemy rigidbody
    private Animator animator;



    // unity's start function
    void Start()
    {
        withinRange = 12f;   // Chases player, within range of player
        speedMovement = 3f;   // enemy speed
        //offSetPosition = 2f;   // distance from enemy to player

        agent = GetComponent<NavMeshAgent>();   // getting component navmeshagent of enemy 
        destination = agent.destination;    //  desination of agent.destination

        rb = GetComponent<Rigidbody>();   // rigidbody
        animator = GetComponent<Animator>();

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;



    }


    // unity's update function
    void Update()
    {           
        // If enemy is in range chase player otherwise idle
        if(InRange())
        {
            EnemyMove();
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        rb.velocity = Vector3.zero;   
        rb.angularVelocity = Vector3.zero;   //  enemy pushback from projectiles decreased
    }


    // If player comes within range then enemy chases player
    bool InRange()
    {
        if (Vector3.Distance(transform.position, playerPosition.transform.position) < withinRange)
        {
            return true;

        }
        else
        {
            return false;
        }
    }


    // Enemy moves to Player 
    void EnemyMove()
    {
        if (Vector3.Distance(destination, playerPosition.transform.position) > 0.2)  // stops within distance of playerposition
        {

            destination = playerPosition.transform.position;
            agent.destination = destination;
            transform.Translate(Vector3.forward * speedMovement * Time.deltaTime);   // speed of enemy towards player
            animator.SetTrigger("canAttack");
        }
        else
        {
            animator.SetBool("resetAttack", false);
        }

    }

    // If the Enemy is hit by magic then go to the last known position of where enemy got hit from. When within range of player... chase
    void OnCollisionEnter(Collision MagicHit)
    {
        if (MagicHit.gameObject.tag == "Magic")
        {

            EnemyMove();

        }
    }
}

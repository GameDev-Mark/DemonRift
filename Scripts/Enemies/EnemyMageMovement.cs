using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMageMovement : MonoBehaviour
{

    //variables
    public Transform playerPosition;   // position of player

    public float speedMovement;    // enemy speed
    private float stoppingDistance;  // enemy stopping distance from the player's position
    private float retreatDistance;   // how far the enemy should rereat from player's position
    private float withinRange;   // if the player is within in range... 


    private Vector3 destination;    // destination of target
    NavMeshAgent agent;   // component of navmeshagent
    private Rigidbody rb;   // Enemy rigidbody
    public Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        speedMovement = 3f;
        stoppingDistance = 10f;
        retreatDistance = 9f;

        withinRange = 20f;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;


        agent = GetComponent<NavMeshAgent>();   // getting component navmeshagent of enemy 
        destination = agent.destination;    //  desination of agent.destination
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();   // rigidbody
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;   //  enemy pushback from projectiles decreased

        if(InRange()) // if the player is within range attack
        {
            EnemyMageMove();
            transform.LookAt(playerPosition.position);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }      
    }


    // EnemyMovement when player in range 
    void EnemyMageMove()
    {

        
        if (Vector3.Distance(transform.position, playerPosition.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speedMovement * Time.deltaTime);
          
        }
        else if (Vector3.Distance(transform.position, playerPosition.position) < stoppingDistance && Vector3.Distance(transform.position, playerPosition.position) > retreatDistance)
        {
            
            transform.position = this.transform.position;
            
        }
        else if(Vector3.Distance(transform.position , playerPosition.position) < retreatDistance)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, -speedMovement * Time.deltaTime);
            
        }       
    }


    // if the player is within range attack
    bool InRange()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) < withinRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // if the player hits the enemy attack
    void OnCollisionEnter(Collision MagicHit)
    {
        if (MagicHit.gameObject.tag == "Magic")
        {

            EnemyMageMove();

        }
    }


}

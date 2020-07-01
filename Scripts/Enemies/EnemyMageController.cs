using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMageController : MonoBehaviour
{
    //variables
    public int enemyMageHealth;   // Enemy's health
    private int enemyMageCurrentHealth;    //Enemy's current health
    private int playerDamage;   // Enemy's damage with magic
    private float fireRate;     // speedrate of magic   

    public GameObject castFrom;    // where the magic is shooting from
    public GameObject enemyMagic;     // Getting the prefab magic to shoot
    public GameObject EnemyCastStartVFX;   // Enemy vfx start cast 
    public Transform healthSpriteBar;   // Sprite health bar

    private Transform playerPosition;     // Getting the players position

    public AudioClip enemyDeathSound;
    public AudioClip magicHitDamage;


    Vector3 destination;    // desination of enemy position
    NavMeshAgent agent;     // NavMesh agent component
    private Animator animator;



    // unity's start function
    void Start()
    {
        enemyMageHealth = 100;  // Enemy's set health
        enemyMageCurrentHealth = enemyMageHealth;  // Enemy's currenthealth         
        playerDamage = 50;  // player's damage with magic

        fireRate = 800;    // speed rate of magic

        agent = GetComponent<NavMeshAgent>();   // getting component navmeshagent of enemy 
        destination = agent.destination;    //  desination of agent.destination
        animator = GetComponent<Animator>();

        InvokeRepeating("EnemyMageAttack", 2f, 2f);     // Invoking the enemy to shoot every x seconds at the player if the player is within range  
        
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // unity's update function
    void Update()
    {
        EnemyMageDeath();            
        
    }


    //enemy shoots magic at player's position when within range
     void EnemyMageAttack()
    {
        if (Vector3.Distance(this.transform.position, playerPosition.transform.position) < 20)
        {
            animator.SetTrigger("canShoot");
        }
        else
        {
            animator.SetBool("resetShoot", false);
        }
    }


    public void EnemyMageCanShoot()
    {
        GameObject magicball = GameObject.Instantiate(enemyMagic);
        magicball.transform.position = castFrom.transform.position;
        magicball.GetComponent<Rigidbody>().velocity = transform.forward * fireRate * Time.deltaTime;
        magicball.transform.TransformDirection(playerPosition.transform.position);
        Destroy(magicball, 2);

        var castStartVFX = Instantiate(EnemyCastStartVFX);
        castStartVFX.transform.position = castFrom.transform.position;
        Destroy(castStartVFX, 1);
    }


    // Detection of magic hit - health of enemy
    void OnCollisionEnter(Collision MagicHit)
    {
        if (MagicHit.gameObject.tag == "Magic")
        {
            enemyMageHealth -= enemyMageCurrentHealth = playerDamage;  // taking health away from enemy if hit my magic ball
            healthSpriteBar.transform.localScale -= new Vector3(5f,0f);   // Takes damage away from enemy health bar UI

            AudioSource.PlayClipAtPoint(magicHitDamage, this.transform.position);
        }
    }


    // Destroying enemy when enemy health == 0 
    void EnemyMageDeath()
    {
        if (enemyMageHealth <= 0)
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(enemyDeathSound, this.transform.position);
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeController : MonoBehaviour
{

    //Variables 
    private int enemyMeleeHealth;   // Enemy's health
    private int enemyMeleeCurrentHealth;    //Enemy's current health
    private int playerDamage;   // Enemy's damage with magic

    public Transform playerPosition;

    public Transform healthBarSprite;

    public AudioClip enemyDeathSound;
    public AudioClip magicHitDamage;


    // unitys start function
    void Start()
    {
        enemyMeleeHealth = 100;  // Enemy's set health
        enemyMeleeCurrentHealth = enemyMeleeHealth;  // Enemy's currenthealth         
        playerDamage = 50;  // player's damage with magic


        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // unitys update function
    void Update()
    {
        EnemyMeleeDeath(); //Enemy death
    }


    // Detection of magic hit - health of enemy
    void OnCollisionEnter(Collision MagicHit)
    {
        if(MagicHit.gameObject.tag == "Magic")
        {
            enemyMeleeHealth -= enemyMeleeCurrentHealth = playerDamage;  // taking health away from enemy if hit my magic ball
            healthBarSprite.transform.localScale -= new Vector3(5f, 0f);

            AudioSource.PlayClipAtPoint(magicHitDamage, this.transform.position);

        }
    }
  

    // Destroying enemy when enemy health == 0 
    void EnemyMeleeDeath()
    {
        if(enemyMeleeHealth <= 0)
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(enemyDeathSound, this.transform.position);

        }
    }
}

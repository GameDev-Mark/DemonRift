using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Variables
    public int playerHealth;
    private int playerCurrentHealth;
    public int playerMaxHealth;
    private int meleeEnemyDamage;
    private int playerHealthPickUp;

    private Rigidbody rb;

    public Slider healthSlider;
    public Slider manaSlider;

    public GameObject _playerObj;
    private MagicBall _playerScript;

    private int manaPotPickUp;

    public AudioClip enemyMagicDamage;
    public AudioClip playerDeath;



    // unitys start function
    void Start()
    {
        _playerScript = _playerObj.GetComponent<MagicBall>();

        manaPotPickUp = 25;

        playerHealth = 100;
        playerCurrentHealth = playerHealth;
        playerHealthPickUp = 25;
        playerMaxHealth = 100;

        meleeEnemyDamage = 5;

        rb = GetComponent<Rigidbody>();

       // Physics.IgnoreLayerCollision(9,10);
    }


    // unitys update function
    void Update()
    {
        PlayerDeath();
       
       // rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    // When enemy comes into contact with player. The player takes damage from the enemy
    void OnCollisionEnter(Collision Enemy)
    {
        if (Enemy.gameObject.tag == "Enemy")      
        {
            playerHealth -= playerCurrentHealth = meleeEnemyDamage;
            healthSlider.value = playerHealth;
            AudioSource.PlayClipAtPoint(enemyMagicDamage, this.transform.position);
        }
    }
    

    // Restores health after pick up
    void OnTriggerEnter(Collider healthPickUp)
    {
        if (healthPickUp.gameObject.tag == "HealthPickUp")
        {
            if (playerHealth < playerMaxHealth)
            {
                playerHealth += playerHealthPickUp = playerCurrentHealth;
                healthSlider.value = playerHealth;
            }
            else if (playerHealth >= playerMaxHealth)
            {

            }
        }

        // restores mana after pick up
        if (healthPickUp.gameObject.tag == "ManaPickUp")
        {
            if (_playerScript.mana < 100)
            {
                _playerScript.mana += manaPotPickUp = _playerScript.currentMana;
                _playerScript.manaSlider.value = _playerScript.mana;
                _playerScript.notEnoughMana.transform.gameObject.SetActive(false);

            }
            else if (_playerScript.mana >= 100)
            {

            }
        }
    }




    // player's death at 0 health
    void PlayerDeath()
    {
        if(playerHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(playerDeath, this.transform.position);
            Destroy(this.gameObject);
            SceneManager.LoadScene("DeathSplashScreen");

        }      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicBall : MonoBehaviour
{
    // variables 
    public GameObject castFrom;   // position where the magicball casts from
    public GameObject _magicBall;   // magicball prefab object
    public GameObject playerCastStartVFX;  // 

    public Slider manaSlider; // 

    private float speedRate;    // speed of magicball

    bool canShoot = true;   // bool if button has been clicked for shooting
    public float coolDown;   // can shoot cooldown

    public int mana;  // mana pool
    public int currentMana;   // current mana
    public int maxMana;
    public int magicManaCost;   // mana cost of spell
    public TMP_Text notEnoughMana;   // no mana text

    private float noManaTextTimer;  // no mana text UI pop up

    public int manaRegen; // mana regenerates

    private Animator animator;  // player animator


    // unity's start function
    void Start()
    {
        maxMana = 100;
        mana = 100;
        currentMana = mana;
        magicManaCost = 10;

        manaRegen = 2;

        speedRate = 30f;   // speed rate of magic projectiles
        coolDown = 2f;  // cool down timer

        noManaTextTimer = 3;

        InvokeRepeating("RegenMana", 1, 1);

        animator = GetComponent<Animator>();

        //_playerMov.GetComponent<PlayerMovement>();

        Time.timeScale = 1;
    }


    // unity's update function
    void Update()
    {
        // Invokes so that you can only shoot every x seconds 
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            FireMagicBall();


            canShoot = false;
            
            Invoke("CooledDown", coolDown);
            //Invoke("ShootEveryX", 1);
        }
    }


    // Instantiates & Projects Magic Ball prefab
    void FireMagicBall()
    {
        if (mana > 0)
        {
            mana -= currentMana = magicManaCost;
            manaSlider.value = mana;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("canShootMagic");
            }
            else
            {
                animator.SetBool("resetShootMagic", false);
            }
        }
        else if (mana <= 0)
        {
            Invoke("noManaclick", noManaTextTimer);
            notEnoughMana.CrossFadeAlpha(1, 3, true);
        }
    }
    

    // regenerates mana every x seconds 
    void RegenMana()
    {      
        if (mana >= maxMana)
        {
            
        }
        else if (mana < maxMana)
        {
            mana += mana = manaRegen;
            manaSlider.value = mana;
        }
    }


    void noManaclick()
    {
        notEnoughMana.gameObject.SetActive(true);    // activate no mana text when player has no mana
        notEnoughMana.CrossFadeAlpha(0, 3, true);
    }


    // Call true if magic is cooled down
    void CooledDown()
    {
        canShoot = true;
    }



    //shoot magic from players position after x amount of seconds when the fire button is clicked
    void ShootEveryX()
    {
        GameObject magicBall = GameObject.Instantiate(_magicBall);
        magicBall.transform.position = castFrom.transform.position;
        magicBall.GetComponent<Rigidbody>().velocity = transform.forward * speedRate;
        Destroy(magicBall, 2);

        var castStartVFX = Instantiate(playerCastStartVFX);
        castStartVFX.transform.position = castFrom.transform.position;
        Destroy(castStartVFX, 1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FreezeGamePlayer : MonoBehaviour
{

    //Variables
    public GameObject player;
    private MagicBall _PlayerMagic;
    private PlayerMovement _PlayerMov;
    public Animator playerAnimFreeze;
    public TMP_Text textProAnim;

    public Collider thisObjCol;

    private float staticTime;

    public AudioClip portalSound;
    public GameObject cameraPos;


    // unitys start function
    private void Start()
    {
        _PlayerMagic = player.GetComponent<MagicBall>();
        _PlayerMov = player.GetComponent<PlayerMovement>();

        staticTime = 5f;

        thisObjCol.GetComponent<BoxCollider>();
    }

    // trigger player stop while text appears...
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            _PlayerMov.enabled = false;
            _PlayerMagic.enabled = false;
            playerAnimFreeze.GetComponent<Animator>().enabled = false;

            
            Invoke("PlayerStatic", staticTime);

            textProAnim.gameObject.SetActive(true);
            textProAnim.CrossFadeAlpha(0, 5.0f, false);

            AudioSource.PlayClipAtPoint(portalSound, cameraPos.transform.position, 0.8f);
        }
    }


    // triggers text to appear for 5 seconds and then re enables player to move again
    public void PlayerStatic()
    { 
        _PlayerMagic.enabled = true;
        _PlayerMov.enabled = true;
        playerAnimFreeze.enabled = true;

        thisObjCol.gameObject.SetActive(false);
    }


}

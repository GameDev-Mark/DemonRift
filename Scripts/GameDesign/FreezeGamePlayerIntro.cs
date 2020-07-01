using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FreezeGamePlayerIntro : MonoBehaviour
{

    //Variables
    public GameObject player;
    private MagicBall _PlayerMagic;
    private PlayerMovement _PlayerMov;  
    public Collider thisObjCol;
    public GameObject panelClose;

    public GameObject storyPanel;


    // unitys start function
    private void Start()
    {
        _PlayerMagic = player.GetComponent<MagicBall>();
        _PlayerMov = player.GetComponent<PlayerMovement>();

        

        thisObjCol.GetComponent<BoxCollider>();
    }


    private void Update()
    {

        PlayerStatic();

    }

    // trigger player stop while text appears...
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            _PlayerMov.enabled = false;
            _PlayerMagic.enabled = false;
                  
        }
    }


    public void PlayerStatic()
    { 
        if(panelClose.activeInHierarchy == false && storyPanel.activeInHierarchy == false)
        {
            _PlayerMagic.enabled = true;
            _PlayerMov.enabled = true;

            thisObjCol.gameObject.SetActive(false);
        }
        
    }


}

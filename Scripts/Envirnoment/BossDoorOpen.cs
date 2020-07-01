using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BossDoorOpen : MonoBehaviour
{

    //Variables
    public Animation bossDoorLeft;
    public Animation bossDoorRight;
    public GameObject player;
    public TMP_Text powerNeededToOpenDoorText;
    public GameObject allPowerGained;
    public TMP_Text opendBossDoorText;
    public TMP_Text press_E_ToOpenDoor;
    public GameObject psDoor;

    public Collider doorCol;  // collider for door .. to block player getting past

    public AudioClip doorActivate;
    public GameObject cameraPos;




    private void OnTriggerStay(Collider playerTrigg)
    {
        if(playerTrigg.CompareTag("Player"))
        {
           
            powerNeededToOpenDoorText.gameObject.SetActive(true);
            powerNeededToOpenDoorText.CrossFadeAlpha(0, 6, false);
         
            if(allPowerGained.gameObject.activeInHierarchy)
            {
                doorCol.gameObject.SetActive(false);
                press_E_ToOpenDoor.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    opendBossDoorText.gameObject.SetActive(true);
                    opendBossDoorText.CrossFadeAlpha(0, 4, false);

                    bossDoorLeft.Play("BossDoorLeftOpen");
                    bossDoorRight.Play("BossDoorRightOpen");

                    psDoor.gameObject.SetActive(false);
                    press_E_ToOpenDoor.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);

                    AudioSource.PlayClipAtPoint(doorActivate, cameraPos.transform.position);

                }
            }
        }
    }

    private void OntriggerExit()
    {
        press_E_ToOpenDoor.gameObject.SetActive(false);
    }

}

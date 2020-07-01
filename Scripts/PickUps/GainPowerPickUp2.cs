using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GainPowerPickUp2 : MonoBehaviour
{

    //Vairables
    public GameObject player;
    public GameObject powerRingimg2;
    public TMP_Text pressE_PickUpText;
    public TMP_Text pickUpPowerGainedText;   
    public TMP_Text powerGained_2_Text;   // turn on power gain text 2s
    public TMP_Text powerGained_1_Text;  // turn off power gain text 1
    public AudioClip pickUpSound;
    private GameObject cameraPos;



    private void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
        
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            pressE_PickUpText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUpPowerGainedText.gameObject.SetActive(true);
                pickUpPowerGainedText.CrossFadeAlpha(0, 4, false);

                powerRingimg2.gameObject.SetActive(true);
                powerGained_2_Text.gameObject.SetActive(true);

                powerGained_1_Text.gameObject.SetActive(false);

                pressE_PickUpText.gameObject.SetActive(false);
                
                Destroy(gameObject);

                AudioSource.PlayClipAtPoint(pickUpSound, cameraPos.transform.position);


            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GainPowerPickUp3 : MonoBehaviour
{

    //Vairables
    public GameObject player;
    public GameObject powerRingimg3;
    public TMP_Text pressE_PickUpText;
    public TMP_Text RestOfPowerGainedText;   
    public TMP_Text powerGained_2_Text;   // turn on power gain text 2s
    public TMP_Text powerGained_3_Text;  // turn off power gain text 1
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
                RestOfPowerGainedText.gameObject.SetActive(true);
                RestOfPowerGainedText.CrossFadeAlpha(0, 4, false);

                powerRingimg3.gameObject.SetActive(true);
                powerGained_3_Text.gameObject.SetActive(true);

                powerGained_2_Text.gameObject.SetActive(false);

                pressE_PickUpText.gameObject.SetActive(false);
                
                Destroy(gameObject);

                AudioSource.PlayClipAtPoint(pickUpSound, cameraPos.transform.position);
            }
        }
    }

}

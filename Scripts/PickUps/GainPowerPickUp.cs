using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GainPowerPickUp : MonoBehaviour
{
    //variables

    public GameObject PowerGainPickUpImg1;   // power gain image UI
    public TMP_Text PowerGainText;  // power gain pick up text
    public TMP_Text PowerRingsGainText1;  // 1-3 rings of power obtained 
    public AudioClip pickUpSound;
    public GameObject cameraPos;


    private void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // When player collides with powergain, gains more power, adds image to UI, text showing picked up power
    void OnTriggerEnter(Collider playerTrigg)
    {
        if (playerTrigg.gameObject.tag == "Player")
        {
            PowerGainPickUpImg1.gameObject.SetActive(true);
            Destroy(gameObject);

            PowerGainText.gameObject.SetActive(true);
            PowerGainText.CrossFadeAlpha(0, 3, false);  // fading the alpha out of the text to zero

            PowerRingsGainText1.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(pickUpSound, cameraPos.transform.position);
        }
    }
}

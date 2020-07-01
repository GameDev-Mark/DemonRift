using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPickUpForDoorScript : MonoBehaviour
{
    //variables

    public GameObject keyPickUpImage1;   // key image UI
    public TMP_Text keyPicktext;  // Key pick up text
    public AudioClip pickUpSound;
    private GameObject cameraPos;

    private void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
    }


    // When player collides with key, picks up key, adds image to UI, text showing picked up key
    void OnTriggerEnter(Collider playerTrigg)
    {
        if(playerTrigg.gameObject.tag == "Player")
        {                  
            keyPickUpImage1.transform.gameObject.SetActive(true);
            Destroy(gameObject);

            keyPicktext.gameObject.SetActive(true);
            keyPicktext.CrossFadeAlpha(0, 2, false);  // fading the alpha out of the text to zero
            AudioSource.PlayClipAtPoint(pickUpSound, cameraPos.transform.position);


        }
    }
}

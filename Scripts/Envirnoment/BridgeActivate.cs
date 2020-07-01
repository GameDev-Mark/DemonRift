using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BridgeActivate : MonoBehaviour
{
    //Variables
    public Animation animLevelPull;
    public GameObject bridge;
    public TMP_Text activateLeverText;
    public TMP_Text leverActivatedText;
    public AudioClip leverActivateSound;
    public GameObject cameraPos;

    private void Start()
    
    {
        animLevelPull.GetComponent<Animation>();
    }


    public void OnTriggerStay(Collider playerTrigg)
    {
        if(playerTrigg.tag == "Player")
        {
            activateLeverText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {             
                animLevelPull.Play("LevelPullActivate");
                bridge.gameObject.SetActive(true);

                activateLeverText.CrossFadeAlpha(0, 1, false);

                leverActivatedText.gameObject.SetActive(true);
                leverActivatedText.CrossFadeAlpha(0, 2, false);

                AudioSource.PlayClipAtPoint(leverActivateSound, cameraPos.transform.position);

            }
        }
    }
}

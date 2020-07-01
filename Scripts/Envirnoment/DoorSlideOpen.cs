using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorSlideOpen : MonoBehaviour
{
    //Variables
    public GameObject _Key;  // gameoject with keyscript attatched to it
    private KeyPickUpForDoorScript _KeyScript; // KeyScript
    public GameObject player;    // Player
    public Animation doorAnim;   // Door animation 
    public GameObject keyPickUpImage;    // image pop on UI when key is picked up
    public TMP_Text openDoorText;   // press e to open door text 
    public TMP_Text doorAccessGranted;   // Door opened text
    public TMP_Text doorIsLocked;
    public AudioClip activateSound;
    public GameObject cameraPos;


    // unity start function
    void Start()
    {
        doorAnim.GetComponent<Animation>();
        _KeyScript = _Key.GetComponent<KeyPickUpForDoorScript>();

    }


    // When player picks up the key and is in range/collides with collider then display text ""press E to open door/animation door open
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && _KeyScript.keyPickUpImage1.transform.gameObject.activeInHierarchy)
        {

            openDoorText.gameObject.SetActive(true);  
        }
        if (Input.GetKeyDown(KeyCode.E) && _KeyScript.keyPickUpImage1.transform.gameObject.activeInHierarchy) // press e to open the door once the player has the key
        {
            doorAnim.Play("DoorOpeningSlide");
            _KeyScript.keyPickUpImage1.gameObject.SetActive(false);
            doorAccessGranted.gameObject.SetActive(true);
            doorAccessGranted.CrossFadeAlpha(0, 3, false);
            doorIsLocked.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(activateSound, cameraPos.transform.position);
        }
        else if(col.tag == "Player")
        {
            doorIsLocked.gameObject.SetActive(true);
        }
    }



    // when player exits trigger area display message disappears..
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            openDoorText.gameObject.SetActive(false);
            doorIsLocked.gameObject.SetActive(false);
        }
    }
}

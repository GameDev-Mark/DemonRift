using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveBoulders : MonoBehaviour
{

    //Variables
    public TMP_Text press_E;
    public List<GameObject> boulder;
    public Collider colBlock;
    public GameObject powerGain2;

    public GameObject cameraPos;
    public AudioClip magicThrow;




    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && powerGain2.gameObject.activeInHierarchy)
        {           
                press_E.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    MoveBoulder();
                    colBlock.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                    AudioSource.PlayClipAtPoint(magicThrow, cameraPos.transform.position);

                }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        press_E.gameObject.SetActive(false);
    }


    private void MoveBoulder()
    {
        for (int i = 0; i < boulder.Count; i++)
        { 
          
            boulder[i].GetComponent<Rigidbody>().AddForce(-50, 0, 1, ForceMode.Force);
            press_E.gameObject.SetActive(false);
        }
    }


}

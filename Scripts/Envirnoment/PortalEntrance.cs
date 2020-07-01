using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalEntrance : MonoBehaviour
{
    //Varirables
    public GameObject player;
    public Text enterPortal;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            enterPortal.gameObject.SetActive(true);
           
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Level1");
            }
        }
        
      
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterPortal.gameObject.SetActive(false);
            
        }
    }
}

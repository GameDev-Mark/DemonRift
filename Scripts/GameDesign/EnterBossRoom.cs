using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterBossRoom : MonoBehaviour
{
    //Variables



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            SceneManager.LoadScene("BossRoom");
        }
           
        
    }


}

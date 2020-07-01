using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisruptRitual : MonoBehaviour
{


    //Variables
    public GameObject player;
    public List<GameObject> enemies;
    public TMP_Text disruptedRitualText;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            disruptedRitualText.gameObject.SetActive(true);
            disruptedRitualText.CrossFadeAlpha(0, 4, false);
            Invoke("WaitTime", 4);

            
        }
    }


    void WaitTime()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(true);

        }
    }


}

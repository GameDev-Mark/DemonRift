using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPickUp : MonoBehaviour
{
    //Variables  
    public List<GameObject> enemies;


    // Update is called once per frame
    private void OnTriggerEnter(Collider playerTrigg)
    {
        if (playerTrigg.tag == "Player")
        {
            

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].SetActive(true);

            }
        }
    }
}

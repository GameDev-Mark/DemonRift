using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthPickUpScript : MonoBehaviour
{
    //Variables
    public GameObject playerObj;
    private PlayerController _playerScript;
    public Collider col;
    public AudioClip pickUpSound;
    private GameObject cameraPos;


    // Unity start function
    void Start()
    {
        _playerScript = playerObj.GetComponentInChildren<PlayerController>();
        col.GetComponent<BoxCollider>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
    }


    //Pick up health..destroys object
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (_playerScript.playerHealth < _playerScript.playerMaxHealth)
            {
               
                col.enabled = !col.enabled;
                col.enabled = enabled.Equals(true);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(pickUpSound, cameraPos.transform.position);
            }
        }
    }
}

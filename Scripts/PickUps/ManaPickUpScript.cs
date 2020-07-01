using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickUpScript : MonoBehaviour
{
    //Variables
    public GameObject playerObj;
    private MagicBall _playerScript;
    public Collider col;
    public AudioClip pickUpSound;
    private GameObject cameraPos;



    // Unity start function
    void Start()
    {

        _playerScript = playerObj.GetComponentInChildren<MagicBall>();
        col.GetComponent<CapsuleCollider>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
    }


    //Pick up health..destroys object
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (_playerScript.mana < _playerScript.maxMana)
            {
                col.enabled = !col.enabled;
                col.enabled = enabled.Equals(true);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(pickUpSound, cameraPos.transform.position);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitMagic : MonoBehaviour
{
    //Variables
    public GameObject magicImpactPrefab;   // on hit magic ps
    public AudioClip magicHitSoundEffect;
    public AudioClip magicHitDamage;



    //Checking if Magic has come into collison with anything...
    void OnCollisionEnter(Collision Enemy)
    {
        ContactPoint contact = Enemy.GetContact(0);  
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);  
        Vector3 pos = contact.point;  

        if(this.gameObject != null)
        {
            var hitVFX = Instantiate(magicImpactPrefab, pos, rot);

            Destroy(hitVFX,1);     // destroying hit PS
            Destroy(this.gameObject);  // destroying this object(magic)

            AudioSource.PlayClipAtPoint(magicHitSoundEffect, Enemy.transform.position);
        }       

    }
}

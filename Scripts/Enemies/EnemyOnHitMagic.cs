using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnHitMagic : MonoBehaviour
{
    //Variables
    public GameObject magicImpactExplosion;
    public AudioClip EnemyMageMagicHitSoundEffect;
   

    //Checking if Magic has hit any collision...
    void OnCollisionEnter(Collision Player)
    {
        ContactPoint contact = Player.GetContact(0);
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(this.gameObject != null)
        {
            var hitVFX = Instantiate(magicImpactExplosion, pos, rot);

            Destroy(hitVFX, 1);
            Destroy(this.gameObject);

            AudioSource.PlayClipAtPoint(EnemyMageMagicHitSoundEffect, Player.transform.position);
        }
    }
}

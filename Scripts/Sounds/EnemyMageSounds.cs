using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageSounds : MonoBehaviour
{
    //Variables
    public AudioClip EnemyMagemagicThrowSoundEffect;
    public GameObject mage;


    public void EnemyMageMagicThrowSE()
    {
        AudioSource.PlayClipAtPoint(EnemyMagemagicThrowSoundEffect, mage.transform.position);
    }

}

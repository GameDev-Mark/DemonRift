using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeSounds : MonoBehaviour
{
    //Variables
    public GameObject enemyMelee;
    public AudioClip enemyMeleeAttackSounds;


    public void MeleeAttackSE()
    {
        AudioSource.PlayClipAtPoint(enemyMeleeAttackSounds, enemyMelee.transform.position);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip magicThrowSoundEffect;
    public AudioClip walkingSoundEffect;
    public GameObject player;



    public void MagicThrowSE()
    {
        AudioSource.PlayClipAtPoint(magicThrowSoundEffect, player.transform.position);
    }


    public void PlayerWalkingSE()
    {
        AudioSource.PlayClipAtPoint(walkingSoundEffect, player.transform.position, 0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DemoicVoice : MonoBehaviour
{
    //Variables
    public TMP_Text youThoughtYouWereSafe;


    private void Awake()
    {
        youThoughtYouWereSafe.gameObject.SetActive(true);
        youThoughtYouWereSafe.CrossFadeAlpha(0, 5, false);
    }
}

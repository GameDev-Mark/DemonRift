using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossRoomPickUp : MonoBehaviour
{
    //Variables
    public TMP_Text textPopUpBoss;
    public Image blackFadeOutComplete;


    private void Start()
    {
        blackFadeOutComplete.canvasRenderer.SetAlpha(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            
            blackFadeOutComplete.CrossFadeAlpha(1, 6, false);
            textPopUpBoss.gameObject.SetActive(true);
            Invoke("BackToMenu", 7);
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("EndSplashScreen");
    }

}

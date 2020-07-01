using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    //Variables
    public GameObject panelClose;
    public GameObject cameraPos;
    public AudioClip buttonClick;
   

    public void UnfreezeContinue()
    {
        StartCoroutine(ContinueWait());
        AudioSource.PlayClipAtPoint(buttonClick, cameraPos.transform.position);
    }

    IEnumerator ContinueWait()
    {
        yield return new WaitForSeconds(1);
        panelClose.SetActive(false);
        SceneManager.LoadScene("IntroLevel");
    }

    
}

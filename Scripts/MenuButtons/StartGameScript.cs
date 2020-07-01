using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGameScript : MonoBehaviour
{
    private float delay;
    public Animation menuBack;
    public Animation menuBack2;
    public AudioClip startSound;
    public GameObject cameraPos;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PlayGame()

    {
        menuBack.Play("MenuBackPop");
        menuBack2.Play("MenuBackPop");

        delay = 6f;

        StartCoroutine(IntroScene(delay));

        AudioSource.PlayClipAtPoint(startSound, cameraPos.transform.position);
    }
    
    IEnumerator IntroScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Story_Controls");

    }
}

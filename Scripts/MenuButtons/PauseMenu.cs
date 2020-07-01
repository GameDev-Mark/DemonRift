using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //Variables
    public GameObject pauseMenuUI;
    public GameObject cameraPos;
    public AudioClip buttonClick;

 
    private void Update()
    {
        Pause();
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(buttonClick, cameraPos.transform.position);
        
    }
    

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }


}

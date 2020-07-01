using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToMainMenuEndScreen : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

}

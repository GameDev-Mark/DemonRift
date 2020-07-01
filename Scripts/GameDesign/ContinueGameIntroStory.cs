using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameIntroStory : MonoBehaviour
{
    //Variables
    public GameObject storyPanel;
    public GameObject controlsPanel;
    public GameObject cameraPos;
    public AudioClip buttonClick;
    public GameObject healthManaBar;



    public void UnfreezeContinueStoryIntro()
    {
        AudioSource.PlayClipAtPoint(buttonClick, cameraPos.transform.position);
        StartCoroutine(("Continue"));
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        storyPanel.SetActive(false);
        controlsPanel.SetActive(true);
        healthManaBar.SetActive(true);

    }

}

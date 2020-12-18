using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUIscript : MonoBehaviour
{
    //GetComponent<Image>().sprite = Image1;

    bool isPaused = false;
    public GameObject GameUIelements;
    public GameObject PauseMenu;
    public GameObject pauseButton;
    public Sprite pause;
    public Sprite play;

    public void pauseGame()
    { 
        if(isPaused)
        {
            pauseButton.GetComponent<Image>().sprite = pause;
            PauseMenu.SetActive(false);
            GameUIelements.SetActive(true);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            pauseButton.GetComponent<Image>().sprite = play;
            GameUIelements.SetActive(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
}

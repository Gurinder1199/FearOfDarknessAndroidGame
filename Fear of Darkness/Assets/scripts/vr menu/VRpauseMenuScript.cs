using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRpauseMenuScript : MonoBehaviour
{
    bool isPaused = false;
    public GameObject PauseMenu;
    public Transform Camera;
    public GameObject pauseMenuContainer;
    public GameObject magneticButtonScriptContainer;

    GvrReticlePointer gvrRetPtrScript;
    public GameObject gvrRetPtr;

    void Start()
    {
        gvrRetPtrScript = gvrRetPtr.GetComponent<GvrReticlePointer>();
    }

    public void pauseGame()
    {
        if (isPaused)
        {
            magneticButtonScriptContainer.SetActive(true);

            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

            gvrRetPtrScript.maxReticleDistance = 20f;
        }
        else
        {
            magneticButtonScriptContainer.SetActive(false);

            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;

            pauseMenuContainer.transform.rotation = Quaternion.Euler(pauseMenuContainer.transform.rotation.x, Camera.rotation.eulerAngles.y, pauseMenuContainer.transform.rotation.x);

            gvrRetPtrScript.maxReticleDistance = 0.3f;
        }
    }
}

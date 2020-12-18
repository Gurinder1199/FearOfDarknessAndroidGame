using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
    public Transform WinnerCanvas;
    public Transform WinnerCanvasContainer;
    public Transform Camera;
    public float timeSpan = 20;
    float currentTime = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("HasWon"))
            PlayerPrefs.SetInt("HasWon", 0);
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("HasWon") == 1)
        {
            WinnerCanvasContainer.rotation = Quaternion.Euler(WinnerCanvasContainer.rotation.x, Camera.rotation.eulerAngles.y, WinnerCanvasContainer.rotation.x);
            currentTime = timeSpan;
            WinnerCanvas.gameObject.SetActive(true);
            PlayerPrefs.SetInt("HasWon", 0);
        }

        if (currentTime == 0)
        {

        }
        else if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            WinnerCanvasContainer.rotation = Quaternion.Euler(WinnerCanvasContainer.rotation.x, Camera.rotation.eulerAngles.y, WinnerCanvasContainer.rotation.x);
        }
        else
        {
            WinnerCanvas.gameObject.SetActive(false);
            currentTime = 0f;
        }

    }


}

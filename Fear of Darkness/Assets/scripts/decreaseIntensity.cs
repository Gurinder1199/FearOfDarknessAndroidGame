using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreaseIntensity : MonoBehaviour
{
    public Light lightSource;
    float lightStep;
 
    void Start()
    {
        lightSource = GetComponent<Light>();
        lightStep = lightSource.intensity / PlayerPrefs.GetInt("countdownMinutes") /60;
    }

    void Update()
    {
        lightSource.intensity -= lightStep * Time.deltaTime;
    }
}

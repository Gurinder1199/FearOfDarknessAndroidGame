using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instantiateSettings : MonoBehaviour
{
    public Slider keyslider;
    public Slider countdownslider;
    public Text countDownText;
    public Text keyText;
    void Start()
    {
        if(!PlayerPrefs.HasKey("NumberOfKeys"))
            PlayerPrefs.SetInt("NumberOfKeys", 3);
        keyslider.GetComponent<Slider>().value = PlayerPrefs.GetInt("NumberOfKeys");
        keyText.text = "Keys : " + PlayerPrefs.GetInt("NumberOfKeys");

        if (!PlayerPrefs.HasKey("countdownMinutes"))
            PlayerPrefs.SetInt("countdownMinutes", 1);
        countdownslider.GetComponent<Slider>().value = PlayerPrefs.GetInt("countdownMinutes");
        countDownText.text = "Countdown : " + PlayerPrefs.GetInt("countdownMinutes")+"min";
    }

    public void SetNumOfKeys(float N)
    {
        PlayerPrefs.SetInt("NumberOfKeys", (int)N);
        keyText.text = "Keys : " + (int)N;
    }

    public void SetCountdownMinutes(float N)
    {
        PlayerPrefs.SetInt("countdownMinutes", (int)N);
        countDownText.text = "Countdown : " + (int)(N) + "min";
    }
}

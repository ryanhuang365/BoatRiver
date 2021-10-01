using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider sensitivity;
    public Text audioText;
    public static bool audio;
    public MenuButtonHandler menu;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Audio") == 2)
        {
            audio = false;
            audioText.text = "OFF";
        }
        else
        {
            audio = true;
            audioText.text = "ON";
        }
        if (PlayerPrefs.GetFloat("MoveSpeed") != 0.0f) {
            sensitivity.value = PlayerPrefs.GetFloat("MoveSpeed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onAudioButtonClicked() {
        audio = !audio;
        if (audio)
        {
            PlayerPrefs.SetInt("Audio", 1);
            audioText.text = "ON";

        }
        else {
            PlayerPrefs.SetInt("Audio", 2);
            audioText.text = "OFF";
        }
    }
    public void onResetHighscoreButtonClicked()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        menu.UpdateHighscore();
    }
    public void sensitivityChanged() {
        ShipController.moveSpeed = sensitivity.value;
        
            PlayerPrefs.SetFloat("MoveSpeed", sensitivity.value);
        
    }
}

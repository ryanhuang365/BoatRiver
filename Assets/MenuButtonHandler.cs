using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    public Canvas gameCanvas;
    public Canvas menuCanvas;
    public GameObject ship;

    public GameObject settingsPanel;
    public Text HighscoreText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighscore();
        ScoreText.text = "Score\n" + ChunkSpawner.prevScore;
    }
    public void UpdateHighscore(){
        HighscoreText.text = "Best\n" + (PlayerPrefs.GetInt("Highscore")).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettingsButtonClicked() {
        if (settingsPanel.gameObject.activeSelf)
        {
            settingsPanel.gameObject.SetActive(false);
        }
        else {
            settingsPanel.gameObject.SetActive(true);
        }
    }
    public void OnSkinsButtonClicked() {
    }
    public void OnPlayButtonClicked() {
        gameCanvas.gameObject.SetActive(true);
        ship.SetActive(true);
        menuCanvas.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
    }
}

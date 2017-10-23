using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseGameSettings : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject helpPanel;
    public Slider volumeSlider;
    Text volumeLabel;
    public void Start()
    {
        volumeLabel = GameObject.Find("VolumeText").GetComponent<Text>();
        unPauseGame();

    }


    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void unPauseGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        hideHelp();
    }

    public void OnValueChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void volumeLabelUpdate(float volumeValue)
    {
        float valueToBeUpdated = Mathf.RoundToInt(volumeValue * 100);
        volumeLabel.text = valueToBeUpdated + "%";
    }

    public void showHelp()
    {
        helpPanel.SetActive(true);
    }

    public void hideHelp()
    {
        helpPanel.SetActive(false);
    }


}
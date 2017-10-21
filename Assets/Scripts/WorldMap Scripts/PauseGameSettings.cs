using UnityEngine;
using System.Collections;

public class PauseGameSettings : MonoBehaviour {
    public GameObject pauseButton;
    public GameObject pausePanel;

    public void Start()
    {
        unPauseGame();
    }


	public void pauseGame(){
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void unPauseGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }


}

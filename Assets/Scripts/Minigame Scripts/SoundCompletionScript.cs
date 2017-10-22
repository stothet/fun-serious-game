﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Simple class used to return to the worldmap. Used in the blowing minigame after the 'Complete' button
//is clicked.
public class SoundCompletionScript : MonoBehaviour
{
    private Button completionButton;
    public void returnToWorld()
    {
        SceneManager.LoadScene(Configuration.worldMapSceneName);
    }
}

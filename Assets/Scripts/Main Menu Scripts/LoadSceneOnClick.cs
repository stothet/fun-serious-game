using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Load another scene
/// </summary>
public class LoadSceneOnClick : MonoBehaviour
{
    // loads the screen according to the index of the screen. This allows for the transition
    // between the different scenes in the main menu
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
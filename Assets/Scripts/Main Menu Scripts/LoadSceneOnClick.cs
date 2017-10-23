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
    public void LoadByState()
    {
        SceneManager.LoadScene(PersistenceController.currentScene);
    }

    public void setCurrentSceneStateByIndex(string name)
    {
        PersistenceController.currentScene = name;
    }

    public void loadAct1()
    {
        string act = Configuration.worldMapSceneName;
        setCurrentSceneStateByIndex(act);
        SceneManager.LoadScene(act);
    }
    public void loadAct2()
    {
        string act = Configuration.act2SceneSceneName;
        setCurrentSceneStateByIndex(act);
        SceneManager.LoadScene(act);
    }
    public void loadMenu()
    {
        string act = Configuration.mainMenuSceneName;
        SceneManager.LoadScene(act); // Don't save menu as last scene
    }
}
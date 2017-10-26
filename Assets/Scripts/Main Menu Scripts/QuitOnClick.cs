using UnityEngine;
using System.Collections;

/// <summary>
/// Closes the scene when the quit button is pressed.
/// </summary>
public class QuitOnClick : MonoBehaviour{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

}
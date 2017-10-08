using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour{
    // Quit method which closes the scene when the quit button is pressed.
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

}
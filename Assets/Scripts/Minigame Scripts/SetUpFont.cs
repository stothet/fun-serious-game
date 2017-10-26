using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Sets the font for the scene.
/// </summary>
public class SetUpFont : MonoBehaviour {
    void Start () {
        setFont();
	}
    private void setFont()
    {
        Text[] allText = FindObjectsOfType<Text>();
        foreach (Text text in allText)
        {
            text.font = Configuration.mathsMinigameFont;
        }
    }

}

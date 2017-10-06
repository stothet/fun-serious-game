using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// Author Andon
/// This is a utility class to update the contents of the description panel when an item is clicked.
/// </summary>
public class UpdateText : MonoBehaviour {
    public Text text;
    public void SetNewText(string txt)
    {
        text.text = txt;
    }
}

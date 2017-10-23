using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveGameButton : MonoBehaviour {
    Button btn;

    // Use this for initialization
    void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        LoadingGameScript ls = new LoadingGameScript();
        ls.save();
    }
}

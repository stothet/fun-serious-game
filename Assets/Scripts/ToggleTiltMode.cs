using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleTiltMode : MonoBehaviour {
    Button btn;
    Camera myCam;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Debug.Log("Testing!");
        GameObject.Find("Main Camera").SendMessage("toggleTiltMode");
    }
}

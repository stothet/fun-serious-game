using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls the end game screen
/// </summary>
public class EndGameController : MonoBehaviour {
    [SerializeField]
    public Text message = null;
    void Start()
    {
		message.text = TrialScript.endGameMessage;
	}
}

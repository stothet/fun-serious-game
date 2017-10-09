using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the message showing on the ending scene depending on the trial
/// </summary>
public class EndGameController : MonoBehaviour {
    [SerializeField]
    public Text message = null;
    void Start()
    {
		message.text = TrialScript.endGameMessage;
	}
}

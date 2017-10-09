using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour {
    [SerializeField]
    public Text message = null;
    void Start()
    {
	        message.text = TrialScript.endGameMessage;
	}
}

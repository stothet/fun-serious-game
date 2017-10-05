using UnityEngine;
using System.Collections;

public class MathsMinigameManager : MonoBehaviour {
        
    MathsMinigame[] games = new MathsMinigame[Configuration.MathsMinigameNumberOfGames];
	
    // Use this for initialization
	void Start () {
	    for (int i = 0; i < games.Length; i++)
        {
            games[i] = new MathsMinigame();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using UnityEngine.UI;
using static MathsMinigame.Operations;

public class MathsMinigameManager : MonoBehaviour {
        
    MathsMinigame[] games = new MathsMinigame[Configuration.MathsMinigameNumberOfGames];

    int currentGame;

    Text[] operations;

    Text[] numbers;

    Text result;

    // Use this for initialization
    void Start () {
	    for (int i = 0; i < games.Length; i++)
        {
            games[i] = new MathsMinigame();
        }
        UpdateTextComponents();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTextComponents();
    }

    void UpdateTextComponents()
    {
        MathsMinigame game = games[currentGame];

        int[] generatedNumbers = game.getGeneratedNumbers();
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            numbers[i] = gameObject.GetComponent<Text>(); 
            numbers[i].text = generatedNumbers[i].ToString();
        }

        MathsMinigame.Operations[] operations = game.getGeneratedOperations();
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            numbers[i] = gameObject.GetComponent<Text>();
            numbers[i].text = generatedNumbers[i].ToString();
        }

    }

}

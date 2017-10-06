using UnityEngine;
using UnityEngine.UI;
//using static MathsMinigame.Operations;

public class MathsMinigameManager : MonoBehaviour {
        
    /*MathsMinigame[] games = new MathsMinigame[Configuration.MathsMinigameNumberOfGames];

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

    // Associates the components which will hold text in the minigame with 
    void initialiseComponents()
    {
        MathsMinigame game = games[currentGame];

        for (int i = 1; i <= numbers.Length; i++)
        {
            numbers[i] = GameObject.Find("NumberHolder" + i).GetComponent<Text>();
        }

        for (int i = 1; i <= operations.Length; i++)
        {
            numbers[i] = GameObject.Find("OperationHolder" + i).GetComponent<Text>();
        }

        result = GameObject.Find("answer").GetComponent<Text>();
    }

    void UpdateTextComponents()
    {
        MathsMinigame game = games[currentGame];

        int[] generatedNumbers = game.getGeneratedNumbers();
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            numbers[i].text = generatedNumbers[i].ToString();
        }

        MathsMinigame.Operations[] generatedOperations = game.getGeneratedOperations();
        for (int i = 0; i < generatedOperations.Length; i++)
        {
            switch (generatedOperations[i])
            {
                case Add:
                    operations[i].text = "+";
                    break;
                case Subtract:
                    operations[i].text = "-";
                    break;
                case Multiply:
                    operations[i].text = "×";
                    break;
                case Divide:
                    operations[i].text = "÷";
                    break;
            }
            operations[i].text = operations[i].ToString();
        }

        result.text = game.getResult().ToString();

    }
*/
}

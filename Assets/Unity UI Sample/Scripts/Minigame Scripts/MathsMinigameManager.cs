using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD:Assets/Scripts/Minigame Scripts/MathsMinigameManager.cs
//using static MathsMinigame.Operations;
=======
>>>>>>> origin/MainMenu:Assets/Unity UI Sample/Scripts/Minigame Scripts/MathsMinigameManager.cs

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
        initialiseComponents();
        UpdateTextComponents();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTextComponents();
    }

    // Associates the components which will hold text in the minigame with local fields.
    void initialiseComponents()
    {
        /*MathsMinigame game = games[currentGame];
        numbers = new Text[Configuration.MathsMinigameNumberOfIntegersPerGame];
        for (int i = 1; i <= numbers.Length; i++)
        {
            numbers[i] = GameObject.Find("NumberHolder" + i).GetComponent<Text>();
            if (numbers[i] == null)
            {
                throw new UnityException("Unable to locate number" + i);
            }
        }
        operations = new Text[Configuration.MathsMinigameNumberOfIntegersPerGame - 1];
        for (int i = 1; i <= operations.Length; i++)
        {
            operations[i] = GameObject.Find("Operation" + i).GetComponent<Text>();
            if (operations[i] == null)
            {
                throw new UnityException("Unable to locate operation" + i);
            }
        }

        result = GameObject.Find("answer").GetComponent<Text>();*/
    }

    void UpdateTextComponents()
    {
        /*MathsMinigame game = games[currentGame];

        int[] generatedNumbers = game.getGeneratedNumbers();
        for (int i = 1; i <= generatedNumbers.Length; i++)
        {
            Debug.Log("Numbers[i] " + numbers[i]);
            Debug.Log("i " + i);
            numbers[i].text = generatedNumbers[i].ToString();
        }

        Operations[] generatedOperations = game.getGeneratedOperations();
        for (int i = 1; i <= generatedOperations.Length; i++)
        {
            switch (generatedOperations[i])
            {
                case Operations.Add:
                    operations[i].text = "+";
                    break;
                case Operations.Subtract:
                    operations[i].text = "-";
                    break;
                case Operations.Multiply:
                    operations[i].text = "×";
                    break;
                case Operations.Divide:
                    operations[i].text = "÷";
                    break;
            }
            operations[i].text = operations[i].ToString();
        }

        result.text = game.getResult().ToString();*/

    }
*/
}

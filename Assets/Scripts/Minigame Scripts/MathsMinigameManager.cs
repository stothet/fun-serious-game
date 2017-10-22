using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the different rounds when playing the Maths minigame 
/// </summary>
/// <remarks>
/// Sets and manages the displayed text in the UI.
/// Determines if the player's answer is correct
/// </remarks>
public class MathsMinigameManager : MonoBehaviour
{
    MathsMinigame[] games = new MathsMinigame[Configuration.mathsMinigameNumberOfGames];    // create multiple math rounds
    int currentGame;                        // stores the current round

    [SerializeField]
    private Text[] numbers = null;          // store the text that hold the numbers

    [SerializeField]
    private Text[] operations = null;       // store the text that holds the operations                                                

    [SerializeField]
    private Text answer = null;             // stores the calculated answer result

    [SerializeField]
    public GameObject[] answerSlots = null; // stores the objects in the answer slots - public for testing

    [SerializeField]
    private GameObject[] numberSlots = null;// stores the objects in the number slots

    [SerializeField]
    private Text errorMessage = null;       // store the text that displays the error messages

    /// <summary>
    /// Initialises the MathsMiniGameManager 
    /// </summary>
    /// <remarks>
    /// Creates an array on minigame rounds
    /// </remarks>
    void Start()
    {
        currentGame = 0;
        for (int i = 0; i < games.Length; i++)
        {
            games[i] = new MathsMinigame();
        }
        UpdateTextComponents();
    }

    /// <summary>
    /// Called on initialisation, update and whenever a game is won to update the text in all of the components.
    /// </summary>
    void UpdateTextComponents()
    {
        MathsMinigame game = games[currentGame];

        int[] generatedNumbers = game.getGeneratedNumbers();
        Operations[] generatedOperations = game.getGeneratedOperations();
        int result = game.getResult();

        setText(generatedNumbers, generatedOperations, result, null);

    }

    /// <summary>
    /// Checks the win conditions of the minigame.
    /// </summary>
    /// <remarks>
    /// If minigame has successfully completed, then the next one in the game list is started.
    /// If all games have been completed, the minigame scene transitions back to the world map.
    /// </remarks>
    public void checkWinConditions()
    {
        Text[] textArr = new Text[answerSlots.Length];
        bool isFilledIn = true;
        for (int i = 0; i < textArr.Length; i++)
        {
            textArr[i] = answerSlots[i].GetComponentInChildren<Text>();
            if (textArr[i] == null)
            {
                isFilledIn = false;
            }
        }

        bool isSuccessful = false;
        if (isFilledIn)
        {
            isSuccessful = calculateResults(textArr);
            Debug.Log("Was successful: " + isSuccessful);

        }

        // If successful
        if (isSuccessful)
        {
            // If there is another game
            currentGame++;
            if (currentGame > games.Length - 1)
            {
                Debug.Log("currentGame = " + currentGame);
                // Transition to next scene, minigame complete!
                SceneManager.LoadScene(Configuration.worldMapSceneName);
            }
            else
            {
                setErrorMessage("Correct");
                setErrorMessageColour(Configuration.mathsMinigameSuccessColourR, Configuration.mathsMinigameSuccessColourG, Configuration.mathsMinigameSuccessColourB);
                resetSlotPositions();
                UpdateTextComponents();
            }
        }
        else
        {
            if (isFilledIn)
            {
                // Not successful
                setErrorMessage("Your answer is incorrect.");
            }
            else
            {
                Debug.Log("Was null: ");
                setErrorMessage("Please make sure that all slots have a number assigned.");
            }
        }
    }

    ////// Helper Methods //////

    /// <summary>
    /// Set the text in the UI
    /// </summary>
    private void setText(int[] generatedNumbers, Operations[] generatedOps, int result, string newErrorMessage)
    {
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            //Debug.Log(generatedNumbers[i].ToString());
        }
        // Set numbers
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != null)
            {
                numbers[i].text = generatedNumbers[i] + "";
            }
        }

        // Set operations
        for (int i = 0; i < operations.Length; i++)
        {
            if (operations[i] != null)
            {
                operations[i].text = opToString(generatedOps[i]);
            }
        }

        // Set answer
        if (answer != null)
        {
            answer.text = result + "";
        }
        // Set message
        if (newErrorMessage != null)
        {
            errorMessage.text = newErrorMessage;
        }
    }
    /// <summary>
    /// Set the text for the errors messages
    /// </summary>
    private void setErrorMessage(string localErrorMessage)
    {
        errorMessage.text = localErrorMessage;
        setErrorMessageColour(Configuration.mathsMinigameErrorColourR, Configuration.mathsMinigameErrorColourG, Configuration.mathsMinigameErrorColourB);
    }



    /// <summary>
    /// Convert an Operation object into a string
    /// </summary>
    private string opToString(Operations op)
    {
        switch (op)
        {
            case (Operations.Add):
                return "+";
            case (Operations.Subtract):
                return "-";
            case (Operations.Multiply):
                return "X";
            case (Operations.Divide):
                return "÷";
            default:
                throw new System.Exception("Unsupported operation: " + op);
        }
    }

    /// <summary>
    /// Check if the player's answer is equal tot eh actual answer
    /// </summary>
    /// <param name="textArr"> The text inside the answer slots </param>
    /// <returns>
    /// Return True if the player's answer is correct. Return False if not
    /// </returns>
    private bool calculateResults(Text[] textArr)
    {
        MathsMinigame game = games[currentGame];
        int results = game.getResult();
        Operations[] ops = game.getGeneratedOperations();

        int[] textInts = new int[textArr.Length];
        for (int i = 0; i < textInts.Length; i++)
        {
            textInts[i] = int.Parse(textArr[i].text);
        }

        return (results == MathsMinigame.CalculateResult(textInts, ops));
    }

    /// <summary>
    /// Resets the positions of the slots and numbers
    /// </summary>
    private void resetSlotPositions()
    {
        for (int i = 0; i < answerSlots.Length; i++)
        {
            Transform answerSlotChild = answerSlots[i].transform.GetChild(0);
            answerSlotChild.SetParent(numberSlots[i].transform);
        }
    }

    private void setErrorMessageColour(float r, float g, float b)
    {
        errorMessage.color = new Color(r, g, b);
    }

}

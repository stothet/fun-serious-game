using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MathsMinigameManager : MonoBehaviour {
        
    MathsMinigame[] games = new MathsMinigame[Configuration.MathsMinigameNumberOfGames];

    int currentGame;

    [SerializeField]
    private Text[] numbers = null;

    [SerializeField]
    private Text[] operations = null;

    [SerializeField]
    private Text answer = null;

    [SerializeField]
    private GameObject[] answerSlots = null;

    [SerializeField]
    private GameObject[] numberSlots = null;

    [SerializeField]
    private Text errorMessage = null;

    // Use this for initialization
    void Start () {
        currentGame = 0;
	    for (int i = 0; i < games.Length; i++)
        {
            games[i] = new MathsMinigame();
        }
        UpdateTextComponents();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    /**
     * Called on initialisation, update and whenever a game is won to update the text in all of the components.
     * 
     */
    void UpdateTextComponents()
    {
        MathsMinigame game = games[currentGame];

        int[] generatedNumbers = game.getGeneratedNumbers();
        Operations[] generatedOperations = game.getGeneratedOperations();
        int result = game.getResult();

        setText(generatedNumbers, generatedOperations, result, null);

    }
    /**
    * Checks if a minigame has been completed successfully. If it has, then the next one in the list is started.
    * If all games have been completed, the minigame scene transitions back to the real world.
    * 
    */
    public void checkWinConditions() {
   
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
        else
        {
            Debug.Log("Was null: ");
            setErrorMessage("Please make sure that all slots have a number assigned.");
        }

        // If successful
        if (isSuccessful) {
            // If there is another game
            currentGame++;
            if (currentGame > games.Length - 1)
            {
                // Transition to next scene, minigame complete!
            }
            else
            {
                setErrorMessage("Correct");
                setErrorMessageColour(Configuration.MathsMinigameSuccessColourR, Configuration.MathsMinigameSuccessColourG, Configuration.MathsMinigameSuccessColourB);
                resetSlotPositions();
                UpdateTextComponents();
            }
        }
        else
        {
            // Not successful
            setErrorMessage("Your order is incorrect.");

        }
    }





    ////// Helper Methods //////

    // Sets the texts in unity
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
    private void setErrorMessage(string localErrorMessage)
    {
        errorMessage.text = localErrorMessage;
        setErrorMessageColour(Configuration.MathsMinigameErrorColourR, Configuration.MathsMinigameErrorColourG, Configuration.MathsMinigameErrorColourB);
    }



    // Converts an Operation object into a string
    private string opToString(Operations op)
    {
        switch (op)
        {
            case (Operations.Add):
                return "+";
            case (Operations.Subtract):
                return "-";
            case (Operations.Multiply):
                return "×";
            case (Operations.Divide):
                return "÷";
            default:
                throw new System.Exception("Unsupported operation: " + op);
        }
    }

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

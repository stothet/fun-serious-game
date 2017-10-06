using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MathsMinigameManager : MonoBehaviour {
        
    MathsMinigame[] games = new MathsMinigame[Configuration.MathsMinigameNumberOfGames];

    int currentGame;

    [SerializeField]
    private Text number1 = null;
    [SerializeField]
    private Text number2 = null;
    [SerializeField]
    private Text number3 = null;
    [SerializeField]
    private Text number4 = null;

    [SerializeField]
    private Text operation1 = null;
    [SerializeField]
    private Text operation2 = null;
    [SerializeField]
    private Text operation3 = null;

    [SerializeField]
    private Text answer = null;

    [SerializeField]
    private GameObject slot1 = null;
    [SerializeField]
    private GameObject slot2 = null;
    [SerializeField]
    private GameObject slot3 = null;
    [SerializeField]
    private GameObject slot4 = null;

    [SerializeField]
    private Text errorMessage = null;

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

        bool isSuccessful = false;
        Text text1 = slot1.GetComponentInChildren<Text>();
        Text text2 = slot2.GetComponentInChildren<Text>();
        Text text3 = slot3.GetComponentInChildren<Text>();
        Text text4 = slot4.GetComponentInChildren<Text>();

        if (text1 != null && text2 != null && text3 != null && text4 != null)
        {
            isSuccessful = calculateResults(int.Parse(text1.text), int.Parse(text2.text), int.Parse(text3.text), int.Parse(text4.text));
        }
        else
        {
            Debug.Log("Was null: ");
            setErrorMessage("Please make sure that all slots have a number assigned.");
        }



        // If there is another game
        // currentGame++;
        //if ()
        //UpdateTextComponents();

    }





    ////// Helper Methods //////

    // Sets the texts in unity
    private void setText(int[] generatedNumbers, Operations[] generatedOps, int result, string newErrorMessage)
    {
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            //Debug.Log(generatedNumbers[i].ToString());
        }
        shuffleNumbers();
        // Set numbers
        if (number1 != null && number2 != null && number3 != null && number4 != null)
        {
            number1.text = generatedNumbers[0] + "";
            number2.text = generatedNumbers[1] + "";
            number3.text = generatedNumbers[2] + "";
            number4.text = generatedNumbers[3] + "";
        }
        // Set operations
        if (operation1 != null && operation2 != null && operation3 != null)
        {
            operation1.text = opToString(generatedOps[0]);
            operation2.text = opToString(generatedOps[1]);
            operation3.text = opToString(generatedOps[2]);
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
    }

    // Shuffles the order of the numbers
    private void shuffleNumbers()
    {
        /*int tempNumber;
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            int rnd = Random.Range(0, generatedNumbers.Length);
            tempNumber = generatedNumbers[rnd];
            generatedNumbers[rnd] = generatedNumbers[i];
            generatedNumbers[i] = tempNumber;
        }*/
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

    private bool calculateResults(int num1, int num2, int num3, int num4)
    {
        int total = num1;

    return true;

    }

}

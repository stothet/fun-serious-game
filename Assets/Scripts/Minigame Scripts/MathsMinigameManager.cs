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
    private Text message = null;

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
        checkWinConditions();
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
        /*if (slot1.text.Equals() &&
            slot2.)*/
        string text1 = slot1.GetComponentInChildren<Text>().text;
        Debug.Log("text1: " + text1.ToString());     
            
    }

    void OnMouseUp()
    {
        // this object was clicked - do something
        Debug.Log("Xavier Button clicked");
    }




    ////// Helper Methods //////

    // Sets the texts in unity
    private void setText(int[] generatedNumbers, Operations[] generatedOps, int result, string newMessage)
    {
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            //Debug.Log(generatedNumbers[i].ToString());
        }
        shuffleNumbers();
        // Set numbers
        number1.text = generatedNumbers[0] + "";
        number2.text = generatedNumbers[1] + "";
        number3.text = generatedNumbers[2] + "";
        number4.text = generatedNumbers[3] + "";
        // Set operations
        operation1.text = opToString(generatedOps[0]);
        operation2.text = opToString(generatedOps[1]);
        operation3.text = opToString(generatedOps[2]);
        // Set answer
        answer.text = result + "";
        // Set message
        if (message != null)
        {
            message.text = newMessage;
        }
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

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Minigame : MonoBehaviour {
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


    private static int numSmallNumbers = 4;
    private int[] generatedNumbers;
    private Operations[] generatedOps;
    private int result;

    // Use this for initialization
    void Start () {
        generatedNumbers = new int[numSmallNumbers];
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] = Random.Range(1, 10);
        }
        

        generatedOps = new Operations[numSmallNumbers - 1];
        for (int i = 0; i < generatedOps.Length; i++)
        {
            // Assign operations
            int currentOp = Random.Range(0, 3);
            switch (currentOp)
            {
                case (0):
                    generatedOps[i] = Operations.Add;
                    break;
                case (1):
                    generatedOps[i] = Operations.Subtract;
                    break;
                case (2):
                    generatedOps[i] = Operations.Multiply;
                    break;
                case (3):
                    generatedOps[i] = Operations.Divide;
                    break;
            }
        }
        
        // Calculate result
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            if (i == 0)
            {
                result = generatedNumbers[i];
            }
            else
            {
               
                // Apply op + next number
                switch (generatedOps[i - 1])
                {
                    case (Operations.Add):
                        result += generatedNumbers[i];
                        break;
                    case (Operations.Subtract):
                        result -= generatedNumbers[i];
                        break;
                    case (Operations.Multiply):
                        result *= generatedNumbers[i];
                        break;
                    case (Operations.Divide):
                        result /= generatedNumbers[i];
                        break;
                }
            }
        }
        setText();
    }

    //Sets the texts in unity
    private void setText()
    {
        //set numbers
        number1.text = generatedNumbers[0] + "";
        number2.text = generatedNumbers[1] + "";
        number3.text = generatedNumbers[2] + "";
        number4.text = generatedNumbers[3] + "";
        //set operations
        operation1.text = opToString(generatedOps[0]);
        operation2.text = opToString(generatedOps[1]);
        operation3.text = opToString(generatedOps[2]);
        //set answer
        answer.text = getResult() + "";
    }
    //converts an Operation object into a string
    private string opToString(Operations op)
    {
        switch (op)
        {
            case (Operations.Add):
                return "+";
            case (Operations.Subtract):
                return "-";
            case (Operations.Multiply):
                return "*";
            case (Operations.Divide):
                return "/";
            default:
                return null;
        }
    }
    public int[] getGeneratedNumbers()
    {
        return generatedNumbers;
    }

    public Operations[] getGeneratedOperations()
    {
        return generatedOps;
    }

    public int getResult()
    {
        return result;
    }
    // Update is called once per frame
    void Update () {
	
	}
}

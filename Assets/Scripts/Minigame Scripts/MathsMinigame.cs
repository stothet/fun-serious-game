using UnityEngine;
using System.Collections;

public class MathsMinigame {

    private static int numSmallNumbers = Configuration.MathsMinigameNumberOfIntegersPerGame;
    private int[] generatedNumbers;
    private Operations[] generatedOps;
    private int result;

    // Use this for initialization
    public MathsMinigame() {
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
        result = CalculateResult(generatedNumbers, generatedOps);
        
        shuffleNumbers();
    }
    public static int CalculateResult(int[] numbers, Operations[] ops)
    {
        // Calculate result
        int localResult = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i != 0)
            {
                // Apply op + next number
                switch (ops[i - 1])
                {
                    case (Operations.Add):
                        localResult += numbers[i];
                        break;
                    case (Operations.Subtract):
                        localResult -= numbers[i];
                        break;
                    case (Operations.Multiply):
                        localResult *= numbers[i];
                        break;
                    case (Operations.Divide):
                        localResult /= numbers[i];
                        break;
                }
            }
        }
        return localResult;
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

    // Shuffles the order of the numbers
    private void shuffleNumbers()
    {
        int tempNumber;
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            int rnd = Random.Range(0, generatedNumbers.Length);
            tempNumber = generatedNumbers[rnd];
            generatedNumbers[rnd] = generatedNumbers[i];
            generatedNumbers[i] = tempNumber;
        }
    }

}
public enum Operations { Add, Subtract, Multiply, Divide }


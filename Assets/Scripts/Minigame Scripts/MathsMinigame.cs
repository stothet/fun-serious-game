using UnityEngine;
using System.Collections;

public class MathsMinigame {

    private static int numSmallNumbers = Configuration.MathsMinigameNumberOfIntegersPerGame;
    private int[] generatedNumbers;
    private Operations[] generatedOps;
    private int result;

    public enum Operations { Add, Subtract, Multiply, Divide };

    // Use this for initialization
    public MathsMinigame() {
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] = Random.Range(1, 10); 
        }
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

    // Main for testing
    /*static int Main(string[] args)
    {
        MathsMinigameGenerator generator = new MathsMinigameGenerator();
        generator.Start();

        return 0;
    }*/
}

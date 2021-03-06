﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a new round for the Math minigame
/// </summary>
/// <remarks>
/// Randomly generates an array of numbers and mathematical operations. The randomly generated operations are applied to the generated numbers and a result is produced.
/// </remarks>
public class MathsMinigame
{

    private static int numSmallNumbers = Configuration.mathsMinigameNumberOfIntegersPerGame; // number of numbers used for the game
    private int[] generatedNumbers;                                                          // stores an array of randomly generated numbers 
    private Operations[] generatedOps;                                                       // stores an array of randomly generated mathematical operations
    private int result;                                                                      // stores the result of applying the generated operations on the generated numbers

    /// <summary>
    /// Contructor that creates a new round for the math game
    /// </summary>
    public MathsMinigame()
    {
        generatedNumbers = new int[numSmallNumbers];
        for (int i = 0; i < generatedNumbers.Length; i++)
        {
            generatedNumbers[i] = Random.Range(1, 10);
        }
        generatedOps = new Operations[numSmallNumbers - 1];
        for (int i = 0; i < generatedOps.Length; i++)
        {
            // Assign operations
            // No Division for now
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

    /// <summary>
    /// Calculates the result produce by applying the generated operations to the generated numbers 
    /// </summary>
    /// <param name="numbers">The numbers that will be used to the euqation to produce a result</param>
    /// <param name="ops">The operations that will be applied on the array of numbers</param>
    /// <returns>
    /// The calculated result
    /// </returns>
    public static int CalculateResult(int[] numbers, Operations[] ops)
    {
        // Create List
        ArrayList numberList = new ArrayList(numbers);
        ArrayList opsList = new ArrayList(ops);

        // First loop: If addition/subtraction, ignore, if multiplcation, calculate result and remove second value + op from lists.
        // Second loop: Perform all addition and subtraction.

        // Perform multiplication and remove duplicates after multiplication.
        for (int i = 1; i < numbers.Length; i++)
        {

            if ((Operations)opsList[i - 1] == Operations.Multiply)
            {

                numberList[i - 1] = (int)numberList[i] * (int)numberList[i - 1];
                numberList.RemoveAt(i);
                opsList.RemoveAt(i - 1);
                i--;
            }
            if (i >= opsList.Count)
            {
                break;
            }
        }
        // Perform addition / subtraction
        int currentValue = (int)numberList[0];
        for (int i = 1; i < numberList.Count; i++)
        {
            Debug.Log("numbers" + numberList.Count);
            Debug.Log("ops" + opsList.Count);
            Debug.Log("i" + i);
            if ((Operations)opsList[i - 1] == Operations.Add)
            {
                currentValue += (int)numberList[i];
            }
            if ((Operations)opsList[i - 1] == Operations.Subtract)
            {
                currentValue -= (int)numberList[i];
            }
        }


        return currentValue;
    }

    /// <summary>
    /// Returns the array of randomly generated numbers 
    /// </summary>
    /// <returns>
    /// The array of randomly generated numbers
    /// </returns>
    public int[] getGeneratedNumbers()
    {
        return generatedNumbers;
    }

    /// <summary>
    /// Returns the array of randomly generated operations 
    /// </summary>
    /// <returns>
    /// The array of randomly generated operations
    /// </returns>
    public Operations[] getGeneratedOperations()
    {
        return generatedOps;
    }

    /// <summary>
    /// Returns the calculated result 
    /// </summary>
    /// <returns>
    /// The calculated result
    /// </returns>
    public int getResult()
    {
        return result;
    }

    /// <summary>
    /// Shuffles the order of the randomly generated numbers
    /// </summary>
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

/// <summary>
/// An Enum that stores the diffrent types of operations that can be used when calculating a result
/// </summary>
public enum Operations
{
    Add,
    Subtract,
    Multiply,
    Divide
}


using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using NUnit.Framework;


/// <summary>
/// Unit tests for minigame.
/// </summary>
[TestFixture]
public class TestMinigame
{
    /// <summary>
    /// Tests method CalculateResult(). Stub numbers and operators were used to check the result.  
    /// </summary>
    [Test]
    public void testCalculateResult()
    {
        var stubNumberArray = new int[] { 1, 1, 1, 1 };
        var stubOpArray = new Operations[] { Operations.Add, Operations.Subtract, Operations.Multiply };
        var testResult = MathsMinigame.CalculateResult(stubNumberArray, stubOpArray);
        Assert.AreEqual(1, testResult);
    }

    /// <summary>
    /// Tests if result varies everytime you run to check randomness. 
    /// Due to the slight chance of having same combination of numbers and operators, 
    /// while loop was used to check if two results are equal. 
    /// </summary>
    [Test]
    public void testRandomness()
    {
        var minigame = new MathsMinigame();
        var firstResult = minigame.getResult();
        bool existsDifferentResult = false;
        MathsMinigame[] generatedMinigames = new MathsMinigame[30];
        for (int i = 0; i < generatedMinigames.Length; i++)
        {
            generatedMinigames[i] = new MathsMinigame();
            if (firstResult != generatedMinigames[i].getResult())
            {
                existsDifferentResult = true;
            }
        }
        Assert.True(existsDifferentResult);
    }

}

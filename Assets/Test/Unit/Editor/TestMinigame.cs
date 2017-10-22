using UnityEngine;
using UnityEditor;
using NUnit.Framework;

/// <summary>
/// Unit tests for minigame.
/// </summary>
[TestFixture]
public class TestMinigame {
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
        var minigame = new MathsMinigame ();
        var firstResult = minigame.getResult ();
        var isEqual = true;
        while (isEqual) {
            var minigame2 = new MathsMinigame ();
            var result = minigame2.getResult ();
            if (firstResult != result) {
	                isEqual = false;
			}
		}
        Assert.AreEqual (false, isEqual);
    }
} 

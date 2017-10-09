using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class TestMinigame {

    [Test]
    public void testCalculateResult() 
    {
        var stubNumberArray = new int[] { 1, 1, 1, 1 };
        var stubOpArray = new Operations[] { Operations.Add, Operations.Subtract, Operations.Multiply };
        var testResult = MathsMinigame.CalculateResult(stubNumberArray, stubOpArray);
        Assert.AreEqual(1, testResult);
	}

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

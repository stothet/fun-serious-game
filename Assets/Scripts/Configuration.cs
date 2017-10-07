using UnityEngine;
using System.Collections;

public class Configuration {

    // Make sure this is false when releasing the final game
    public static readonly bool isTestMode = true;

    public static readonly int MathsMinigameNumberOfGames = 3;
    public static readonly int MathsMinigameNumberOfIntegersPerGame = 4;

    public static readonly float MathsMinigameSuccessColourR = 65;
    public static readonly float MathsMinigameSuccessColourG = 187;
    public static readonly float MathsMinigameSuccessColourB = 244;

    public static readonly float MathsMinigameErrorColourR = 244;
    public static readonly float MathsMinigameErrorColourG = 91;
    public static readonly float MathsMinigameErrorColourB = 65;

}

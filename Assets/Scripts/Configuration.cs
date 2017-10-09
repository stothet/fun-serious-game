using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Configuration
{

    // Make sure this is false when releasing the final game
    public static readonly bool isTestMode = false;

    public static readonly int MathsMinigameNumberOfGames = 1;
    public static readonly int MathsMinigameNumberOfIntegersPerGame = 4;

    public static readonly float MathsMinigameSuccessColourR = 65.0f / 255.0f;
    public static readonly float MathsMinigameSuccessColourG = 187.0f / 255.0f;
    public static readonly float MathsMinigameSuccessColourB = 244.0f / 255.0f;

    public static readonly float MathsMinigameErrorColourR = 244.0f / 255.0f;
    public static readonly float MathsMinigameErrorColourG = 91.0f / 255.0f;
    public static readonly float MathsMinigameErrorColourB = 65.0f / 255.0f;

    public static readonly string ChangeScenePrompt = "ChangeScene";

    public static readonly string minigameSceneName = "MathsMinigame";
    public static readonly string mainMenuSceneName = "MainMenu";
    public static readonly string worldMapSceneName = "WorldMap";

    public static Font MathsMinigameFont = (Font)Resources.Load("Fonts/kindergarten");

    public static readonly Vector3 playerPosition = new Vector3(-29.69f, -2.14f, 0);
    public static readonly Vector3 lunchLadyPositionTest = new Vector3(-35.0f, -45.0f, 0);
    public static readonly int maxLives = 3;

    public static readonly string bruceRegisterEntryName = "Bruce's register entry";
    public static readonly string BillArtHistoryReportName = "Bill's Art History report, scrunched to a ball.";
    public static readonly string DetentionNoteName = "Detention note";

    public static readonly string bruceRegisterEntryDescription = "Register entry for Bruce, with his signature and an official timestamp.";
    public static readonly string BillArtHistoryReportDescription = "Bill's Art History report, scrunched to a ball.";
    public static readonly string DetentionNoteDescription = "Detention note for Bruce, with the date and time nowhere to be seen.";

}

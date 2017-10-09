using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Configuration
{

    // Make sure this is false when releasing the final game
    public static readonly bool isTestMode = false;

    public static readonly int mathsMinigameNumberOfGames = 1;
    public static readonly int mathsMinigameNumberOfIntegersPerGame = 4;

    public static readonly float mathsMinigameSuccessColourR = 65.0f / 255.0f;
    public static readonly float mathsMinigameSuccessColourG = 187.0f / 255.0f;
    public static readonly float mathsMinigameSuccessColourB = 244.0f / 255.0f;

    public static readonly float mathsMinigameErrorColourR = 244.0f / 255.0f;
    public static readonly float mathsMinigameErrorColourG = 91.0f / 255.0f;
    public static readonly float mathsMinigameErrorColourB = 65.0f / 255.0f;

    public static readonly string changeScenePrompt = "ChangeScene";

    public static readonly string minigameSceneName = "MathsMinigame";
    public static readonly string mainMenuSceneName = "MainMenu";
    public static readonly string worldMapSceneName = "WorldMap";
	public static readonly string endGameSceneName = "EndGame";

    public static Font mathsMinigameFont = (Font)Resources.Load("Fonts/kindergarten");

    public static readonly Vector3 playerPosition = new Vector3(-29.69f, -2.14f, 0);
    public static readonly Vector3 lunchLadyTestPosition = new Vector3(-35.0f, -45.0f, 0);
    public static readonly int maxLives = 3;

    public static readonly string bruceRegisterEntryName = "Bruce's register entry";
    public static readonly string billArtHistoryReportName = "Scrunched up paper";
    public static readonly string detentionNoteName = "Detention note";

    public static readonly string bruceRegisterEntryDescription = "Register entry for Bruce, with his signature and an official timestamp.";
    public static readonly string billArtHistoryReportDescription = "Bill's Art History report, scrunched to a ball.";
    public static readonly string detentionNoteDescription = "Detention note for Bruce, with the date and time nowhere to be seen.";

}

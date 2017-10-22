using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This is a static class that stores the configuration for the game 
/// </summary>
public class Configuration
{
    public static readonly bool isTestMode = false;                             // Enables test mode. Make sure this is false when releasing the final game

    public static readonly int mathsMinigameNumberOfGames = 1;                  // The number of rounds/games when playing the MathsMiniGame
    public static readonly int mathsMinigameNumberOfIntegersPerGame = 4;        // The number of numbers generated when playing the minigame

    // Colour of success message for minigame
    public static readonly float mathsMinigameSuccessColourR = 65.0f / 255.0f;  
    public static readonly float mathsMinigameSuccessColourG = 187.0f / 255.0f; 
    public static readonly float mathsMinigameSuccessColourB = 244.0f / 255.0f;

    // Colour of error message for minigame
    public static readonly float mathsMinigameErrorColourR = 244.0f / 255.0f;
    public static readonly float mathsMinigameErrorColourG = 91.0f / 255.0f;
    public static readonly float mathsMinigameErrorColourB = 65.0f / 255.0f;

    public static readonly string changeScenePrompt = "ChangeScene";            // The prompt used to indicate when to change scene during dialogue

    public static readonly string minigameSceneName = "MathsMinigame";          // Name of the MathsMiniGame scene
    public static readonly string mainMenuSceneName = "MainMenu";               // Name of the MainMenu scene
    public static readonly string worldMapSceneName = "WorldMap";               // Name of the WorldMap scene
    public static readonly string endAct1SceneName = "EndAct1";                 // Name of the EndGame scene

    public static Font mathsMinigameFont = (Font) Resources.Load("Fonts/kindergarten");      // Font used for the minigame

    public static readonly Vector3 playerPosition = new Vector3(-29.69f, -5.53f, 0);        // inital position to spawn the player
    public static readonly Vector3 lunchLadyTestPosition = new Vector3(-35.0f, -45.0f, 0);  // positon to spawn player in the cafeteria
    public static readonly int maxLives = 3;                                                // number of max lives

    // name of items
    public static readonly string bruceRegisterEntryName = "Bruce's register entry";        
    public static readonly string billArtHistoryReportName = "Scrunched up paper";
    public static readonly string detentionNoteName = "Detention note";
	public static readonly string blueDrinkName = "Blue drink";

    // journal descriptions
    public static readonly string bruceRegisterEntryDescription = "Register entry for Bruce, with his signature and an official timestamp.";
    public static readonly string billArtHistoryReportDescription = "Bill's Art History report, scrunched to a ball.";
    public static readonly string detentionNoteDescription = "Detention note for Bruce, with the date and time nowhere to be seen.";
    public static readonly string blueDrinkDescription = "What in tarnation is this?";

}

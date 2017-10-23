using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This is a static class that stores the configuration for the game 
/// </summary>
public class Configuration
{
    public static readonly bool isTestMode = false;                             // Enables test mode. Make sure this is false when releasing the final game
	public static readonly bool isFastAct2Mode = true;                             // Enables fast act 2 mode. Make sure this is false when releasing the final game



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
    public static readonly string worldMapSceneName = "WorldMap";               // Name of the act scene
    public static readonly string endAct1SceneName = "EndAct1";                 // Name of the end act scene
    public static readonly string act2SceneSceneName = "Act 2";                 // Name of the act scene
    public static readonly string endAct2SceneName = "EndAct2";                 // Name of the end act scene
	public static readonly string loseGameSceneName = "LoseGame"; 


	public static readonly string microphoneMinigameSceneName = "MicrophoneMinigame";


    public static Font mathsMinigameFont = (Font) Resources.Load("Fonts/kindergarten");      // Font used for the minigame

    public static readonly Vector3 playerPosition = new Vector3(-29.69f, -5.53f, 0);        // inital position to spawn the player
    public static readonly Vector3 lunchLadyTestPosition = new Vector3(-35.0f, -45.0f, 0);  // positon to spawn player in the cafeteria
    public static readonly int maxLives = 3;                                                // number of max lives

    // name of items
    public static readonly string bruceRegisterEntryName = "Bruce's register entry";        
    public static readonly string billArtHistoryReportName = "Scrunched up paper";
    public static readonly string detentionNoteName = "Detention note";
	public static readonly string blueDrinkName = "Blue drink";
    public static readonly string blueSprayName = "Blue spray";
    public static readonly string principalsKeysName = "Keys to the principal's office";
    public static readonly string photographName = "Group photo of Brad, Jimmy and Bruce";
    public static readonly string capName = "Blue Cap with a red cross";
	public static readonly string examScriptName = "Exam Script";
	public static readonly string cleanPaperName = "Clean Paper";
	public static readonly string dirtyPaperName = "Dirty Paper";
    


    // journal descriptions
    public static readonly string bruceRegisterEntryDescription = "Register entry for Bruce, with his signature for signing in and out. Timestamp states it's from 12.10 to 12.25.";
    public static readonly string billArtHistoryReportDescription = "Bill's Art History report, scrunched to a ball.";
    public static readonly string detentionNoteDescription = "A detention note for Bruce Buckley, the time period says 12.30 to 1. The handwriting seems a bit messy.";
    public static readonly string blueDrinkDescription = "A mysterious blue drink...";
    public static readonly string blueSprayDescription = "A blue window spray cleaner used by Charles.";
    public static readonly string principalsKeysNameDescription = "A key that unlocks the principal's office.";
    public static readonly string photographNameDescription = "A photograph showing Bruce, Brad and Jimmy together. All three are wearing identical blue caps similar to the one found in the crime scene.";
    public static readonly string capNameDescription = "A blue cap.";
	public static readonly string examScriptNameDescription = "Some of the scripts that have been left behind by the culprit. The pages are stained with a blue liquid.";
	public static readonly string cleanPaperNameDescription = "An official janitor's working log. Charles name is signed in for bathroom duty from 12.30 to 1.00.";
	public static readonly string dirtyPaperNameDescription = "A strange scrumpled piece of dusty paper.";
}

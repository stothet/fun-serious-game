using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles the logic for presenting evidence to the principal
/// </summary>
public class TrialScript : MonoBehaviour
{
	//boolean to switch off trial
	public bool trialFinished = false;

	public int order = -1;
	public bool trialActive = false;
	public TextBoxManager txtBox;

	//keeps track of player health
	public GameObject livesKeeper;

	//keeps track of the trial score
	public GameObject scoreKeeper;
	public Text _score;

	//keeps track of number of evidence presented
	int _evidenceCount=0;

	//we will only have 2 options during dialogue
	//the rest will be controlled by evidence presentation
	public Button choice1;
	public Button choice2;
	public Text option1;
	public Text option2;

	//all text files needed for dialogue
	public TextAsset trialStart;
	public TextAsset introFile;
	public TextAsset prelude;
	public TextAsset bruceIsFree;
	public TextAsset goBack;
	public TextAsset youLose;

	// score data type
	public static int cumulative=0;

	//characters
	//public PlayerController player;
	//public NPCController NPC;

	public Item evidence;
	private Inventory inventory;
	private Journal journal;
	private GameObject journalSlot;
	private Button submitButton;
	private Journal godhelpme;

	public static string endGameMessage = null;

	//panel and button would handle this script

	/// <summary>
    /// Initialise variables
    /// </summary>
	void Start ()
	{
		//NPC = FindObjectOfType<NPCController>();
		txtBox = FindObjectOfType<TextBoxManager>();
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		submitButton = GameObject.FindGameObjectWithTag("SubmitButton").GetComponent<Button>();
		
		//journalSlot = GameObject.FindGameObjectWithTag("Journal").GetComponentInChildren<GameObject>();
		
		

		//journaljournal = journalSlot.GetComponent<Journal>();
		submitButton.gameObject.SetActive(false);

		scoreKeeper.SetActive (false);

		choice1.gameObject.SetActive (false);
		choice2.gameObject.SetActive (false);
	}

	/// <summary>
    /// Check if the trial has ended
    /// </summary>
	void Update ()
	{
        Debug.Log("Updating XDXD");
		if (Input.GetKey(KeyCode.Space) && trialFinished) {
            string nextScene = Configuration.endAct1SceneName;
            Debug.Log("Changing to next scene " + nextScene);
            PersistenceController.currentScene = nextScene;
			SceneManager.LoadScene(nextScene);
		}
	}

	/// <summary>
    /// Determine the outcome of the trial
    /// </summary>
	void Outcome()
	{
		trialActive = false;
        Debug.Log("Trial finished");
		trialFinished = true;
		if(cumulative > 0){
			trialDialogue (2);
			endGameMessage = "You Win!";
			//SceneManager.LoadScene(Configuration.endGameSceneName);
			// You win end game screen
		}else if(cumulative == 0){
			trialDialogue (3);
			endGameMessage = "Try Again";
			//SceneManager.LoadScene (Configuration.endGameSceneName);
			//PlayerController.subtractLife();
			livesKeeper.SetActive (true);
		}else{
			trialDialogue (4);
			endGameMessage = "Game Over";
			//SceneManager.LoadScene(Configuration.endGameSceneName);
			// You lose end game screen
		}
	}

    /// <summary>
    /// Keep track of the player score when evidence is selected
    /// </summary>
    void keepScore(int evidenceValue){
		cumulative += evidenceValue;
		_score.text = cumulative.ToString ();


	}

	/// <summary>
    /// Loads the appropriate dialogue based on the players response
    /// </summary>
	public void trialDialogue(int caseSwitch){
        switch (caseSwitch)
		{

		case -1:

		{
				if (Configuration.isFastAct2Mode)
				{
					Outcome();
				}
				order = 0;
				txtBox.ReloadScript(introFile);

				choice1.gameObject.SetActive (true);
				choice2.gameObject.SetActive (true);

				break;
			}

		case 0:

		{
			order = 1;
				trialActive = true;
				txtBox.ReloadScript(trialStart);
				txtBox.ContinueDialogue();

				option1.text = "You were right to doubt him, Mr. Wilson!";
				option2.text = "It was not Bruce who did it...";

				scoreKeeper.SetActive (true);
				livesKeeper.SetActive (false);
                break;
			}

		case 1:

		{
			order = 2;
				txtBox.ReloadScript(prelude);
				txtBox.ContinueDialogue();

				choice1.gameObject.SetActive (false);
				choice2.gameObject.SetActive (false);


				break;
			}

		case 2:

			{

				txtBox.ReloadScript(bruceIsFree);
				txtBox.ContinueDialogue();
				break;
			}
		case 3:

			{

				txtBox.ReloadScript(goBack);
				txtBox.ContinueDialogue();
				break;
			}

		case 4:

			{

				txtBox.ReloadScript(youLose);
				txtBox.ContinueDialogue();
				break;
			}

		default:
			{
				break;
			}

		}
		/*
		if (Configuration.isFastAct2Mode)
		{
			Outcome();
		}
*/
	}

    /// <summary>
    /// Select an item from the inventory and update the players score
    /// </summary>
	public void SelectObjectEvidence(){
	    godhelpme = GameObject.FindGameObjectWithTag("JournalSlot").GetComponent<Journal>();
	    
	    Debug.Log(godhelpme.GetSelectedEntry() +"");
        if (inventory.GetSelectedItem() != null)
		{
			
			evidence = inventory.GetSelectedItem();
			keepScore(evidence._itemValue);
			_evidenceCount++;
			//if(_evidenceCount == 2){
				Outcome ();
			//}

		}
		else if (godhelpme.GetSelectedEntry() != 9999999)
        {
	        keepScore(godhelpme.GetSelectedEntry());
        }
		else{
			// Do nothing as nothing is selected
			return;
		}
	}


	/// <summary>
	/// Checks with dialgogue option has been selected
	/// </summary>
	/// <param name="b"> The button clicked </param>
	public void CheckClick(Button b)
	{
		switch (order)
		{
			case 0: {
				if (Button.ReferenceEquals(choice1, b))
				{
					/**
					//depending on the level
					if (inventory._items.Count == 3)
					{
						trialDialogue(1);
						submitButton.gameObject.SetActive(true);
					}**/

					trialDialogue(0);
				}

				else
				{
					txtBox.currentLine = 0;
					txtBox.DisableDialogueBox();
					return;
				}
				break;

			}

			case 1:
			{
				trialDialogue(1);
				break;
			}

			default:
			{
				break;
			}

		}

		/**LEADS TO END GAME SCREEN (KEEP PRESSING SPACE)
		_evidenceCount++;
		if (_evidenceCount == 2)
		{
			Outcome();
		}**/
	}

}

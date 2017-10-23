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
    public bool presentEvidenceNow = false;

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

	//all text files needed for dialogue in Act 1
	public TextAsset trialStart;
	public TextAsset introFile;
	public TextAsset prelude;
	public TextAsset bruceIsFree;
	public TextAsset goBack;
	public TextAsset youLose;

	// score data type
	public static int cumulative=0;

	public Item evidence;
	private Inventory inventory;
	private Journal journal;
	private GameObject journalSlot;
	private Button submitButton;
    public string evidenceRequired;
    private int currentCaseSwitch;
	private Journal godhelpme;

	public static string endGameMessage = null;

	//panel and button would handle this script

	/// <summary>
    /// Initialise variables
    /// </summary>
	void Start ()
	{
		txtBox = FindObjectOfType<TextBoxManager>();
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		submitButton = GameObject.FindGameObjectWithTag("SubmitButton").GetComponent<Button>();
        evidenceRequired = "none";
		submitButton.gameObject.SetActive(false);

		scoreKeeper.SetActive (false);
	}

	/// <summary>
    /// Check if the trial has ended
    /// </summary>
	void Update ()
	{
		if ( (Input.GetKey(KeyCode.Space) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
			&& trialFinished) {
			string nextScene = null;
			string sceneName = SceneManager.GetActiveScene ().name;
			if (sceneName == Configuration.act2SceneSceneName) {
				nextScene = Configuration.endAct2SceneName;
			}
			else if (sceneName == Configuration.worldMapSceneName) {
				nextScene = Configuration.endAct1SceneName;
			}
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

        this.currentCaseSwitch = caseSwitch;

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
                    txtBox.ContinueDialogue();

				choice1.gameObject.SetActive (true);
				choice2.gameObject.SetActive (true);
                    txtBox.disableDialogueTap = true;
				break;
			}

		case 0:

		{
                    Debug.Log("lost a life");
			order = 1;
				trialActive = true;
				txtBox.ReloadScript(trialStart);
				txtBox.ContinueDialogue();

                    /*option1.text = "You were right to doubt him, Mr. Wilson!";
                    option2.text = "It was not Bruce who did it...";*/
                    evidenceRequired = "Selma: School's reception lady. Swears she hasn't seen anyone sneak by her while she was at her desk. Was away from desk from 12.30 - 12.40.";
				//scoreKeeper.SetActive (true);
				//livesKeeper.SetActive (false);
                    presentEvidenceNow = true;
                if (Configuration.isFastAct2Mode)
                {
                    Outcome();
                }
                break;
			}

		case 1:

		{
			order = 2;
				txtBox.ReloadScript(prelude);
				txtBox.ContinueDialogue();
                    presentEvidenceNow = true;
                    evidenceRequired = Configuration.bruceRegisterEntryName;
                    break;
			}

		case 2:

			{

				txtBox.ReloadScript(bruceIsFree);
				txtBox.ContinueDialogue();
                evidenceRequired = "finished";
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
	}

    /// <summary>
    /// Select an item from the inventory and update the players score
    /// </summary>
	public void SelectObjectEvidence(){
        if (inventory.GetSelectedItem() != null)
		{
            presentEvidenceNow = false;
            txtBox.disableDialogueTap = false;
			evidence = inventory.GetSelectedItem();
            if (evidenceRequired.Equals(evidence._itemName))
            {
                trialDialogue(order);
            } else
            {
                trialDialogue(currentCaseSwitch);
                PersistenceController.instance.playerState.lives--;
                if(PersistenceController.instance.playerState.lives == 0)
                {
					SceneManager.LoadScene(Configuration.loseGameSceneName);
                }
            }
			keepScore(evidence._itemValue);
			_evidenceCount++;

		}
		else
        {
<<<<<<< HEAD
=======
	        godhelpme = GameObject.FindGameObjectWithTag("JournalSlot").GetComponent<Journal>();
	        presentEvidenceNow = false;
	        txtBox.disableDialogueTap = false;
	        //Debug.Log(godhelpme.GetSelectedEntry() +"");
	        Text t = godhelpme.GetComponentInChildren<Text>();
	        string clickedName = t.text;
	        if (evidenceRequired.Equals(clickedName))
	        {
		        trialDialogue(order);
	        }
	        else
	        {
		        trialDialogue(currentCaseSwitch);
		        PersistenceController.instance.playerState.lives--;
		        if(PersistenceController.instance.playerState.lives == 0)
		        {
			        SceneManager.LoadScene(Configuration.endAct1SceneName);
		        }
	        }
	        //if(godhelpme.)
>>>>>>> a32dbfc6d0c88ffb67a19d2646cfa074bf44cb30
	        keepScore(godhelpme.GetSelectedEntry());
	        godhelpme.journalEntryValue = 0;
	        _evidenceCount++;
        }
	}

    /// <summary>
	/// Checks with dialgogue option has been selected
	/// </summary>
	/// <param name="b"> The button clicked </param>
	public void CheckClick(Button b)
    {
        txtBox.disableDialogueTap = false;
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        switch (order)
        {
            case 0:
                {
                    if (Button.ReferenceEquals(choice1, b))
                    {
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
    }

}

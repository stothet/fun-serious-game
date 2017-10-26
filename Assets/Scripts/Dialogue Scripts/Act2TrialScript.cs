﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles the logic for presenting evidence to the principal
/// </summary>
public class Act2TrialScript : MonoBehaviour
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
    int _evidenceCount = 0;

    //we will only have 2 options during dialogue
    //the rest will be controlled by evidence presentation
    public Button choice1;
    public Button choice2;
    public Text option1;
    public Text option2;

    //all text files needed for dialogue in Act 2
    public TextAsset keyInDetention;
    public TextAsset rileyJournal;
    public TextAsset hatPhoto;
    public TextAsset ritaJournal;
    public TextAsset blueDrink;
    public TextAsset blueSprayer;
    public TextAsset blueLiquidPrompt;
    public TextAsset wilsonConfused;
    public TextAsset trialIntro;

    // score data type
    public static int cumulative = 0;

    //characters
    //public PlayerController player;
    //public NPCController NPC;

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
    void Start()
    {
        //NPC = FindObjectOfType<NPCController>();
        txtBox = FindObjectOfType<TextBoxManager>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        submitButton = GameObject.FindGameObjectWithTag("SubmitButton").GetComponent<Button>();
        evidenceRequired = "none";
        //journalSlot = GameObject.FindGameObjectWithTag("Journal").GetComponentInChildren<GameObject>();



        //journaljournal = journalSlot.GetComponent<Journal>();
        submitButton.gameObject.SetActive(false);

        scoreKeeper.SetActive(false);

        /*choice1.gameObject.SetActive (false);
		choice2.gameObject.SetActive (false);*/
    }

    /// <summary>
    /// Check if the trial has ended
    /// </summary>
    void Update()
    {
        Debug.Log("Updating XDXD");
        if ((Input.GetKey(KeyCode.Space) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
            && trialFinished)
        {
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
        if (cumulative > 0)
        {
            trialDialogue(2);
            endGameMessage = "You Win!";
            //SceneManager.LoadScene(Configuration.endGameSceneName);
            // You win end game screen
        }
        else if (cumulative == 0)
        {
            trialDialogue(3);
            endGameMessage = "Try Again";
            //SceneManager.LoadScene (Configuration.endGameSceneName);
            //PlayerController.subtractLife();
            livesKeeper.SetActive(true);
        }
        else
        {
            trialDialogue(4);
            endGameMessage = "Game Over";
            //SceneManager.LoadScene(Configuration.endGameSceneName);
            // You lose end game screen
        }
    }

    /// <summary>
    /// Keep track of the player score when evidence is selected
    /// </summary>
    void keepScore(int evidenceValue)
    {
        cumulative += evidenceValue;
        _score.text = cumulative.ToString();
    }

    /// <summary>
    /// Loads the appropriate dialogue based on the players response
    /// </summary>
    public void trialDialogue(int caseSwitch)
    {

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
                    txtBox.ReloadScript(trialIntro);
                    txtBox.ContinueDialogue();

                    choice1.gameObject.SetActive(true);
                    choice2.gameObject.SetActive(true);
                    txtBox.disableDialogueTap = true;
                    break;
                }

            case 0:

                {
                    order = 1;
                    trialActive = true;
                    txtBox.ReloadScript(blueLiquidPrompt);
                    txtBox.ContinueDialogue();

                    evidenceRequired = Configuration.blueDrinkName;
                    
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
                    txtBox.ReloadScript(blueDrink);
                    txtBox.ContinueDialogue();
                    presentEvidenceNow = true;
                    evidenceRequired = "Lunchlady Rita: Sold three blue drinks today, to Brad, Jimmy, and Bruce.";
                    break;
                }

            case 2:

                {
                    order = 3;
                    txtBox.ReloadScript(ritaJournal);
                    txtBox.ContinueDialogue();
                    presentEvidenceNow = true;
                    evidenceRequired = Configuration.photographName;
                    break;
                }
            case 3:

                {
                    order = 4;
                    txtBox.ReloadScript(hatPhoto);
                    txtBox.ContinueDialogue();
                    presentEvidenceNow = true;
                    evidenceRequired = "Riley: Jimmy's Mom, here to pick up Jimmy. Complains that her son gets into detention a lot, unlike good boy Brad who never does.";
                    break;
                }

            case 4:

                {
                    order = 5;
                    txtBox.ReloadScript(rileyJournal);
                    txtBox.ContinueDialogue();
                    presentEvidenceNow = true;
                    evidenceRequired = Configuration.principalsKeysName;
                    break;
                }

            case 5:

                {
                    txtBox.ReloadScript(keyInDetention);
                    txtBox.ContinueDialogue();
                    evidenceRequired = "finished";
                    break;
                }

            case 99:

                {
                    txtBox.ReloadScript(blueSprayer);
                    txtBox.ContinueDialogue();
                    presentEvidenceNow = true;
                    evidenceRequired = "Haha you can't win from here";
                    break;
                }

            default:
                {
                    Debug.Log("r u going in here");
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
	public void SelectObjectEvidence()
    {
        //godhelpme = GameObject.FindGameObjectWithTag("JournalSlot").GetComponent<Journal>();

        //Debug.Log(godhelpme.GetSelectedEntry() +"");
        if (inventory.GetSelectedItem() != null)
        {
            presentEvidenceNow = false;
            txtBox.disableDialogueTap = false;
            evidence = inventory.GetSelectedItem();
            if (evidence._itemName.Equals(evidenceRequired))
            {
                trialDialogue(order);
            }
            else
            {
                if (currentCaseSwitch == 0 && evidence._itemName.Equals(Configuration.blueSprayName))
                {
                    trialDialogue(99);
                }

                trialDialogue(currentCaseSwitch);
                PersistenceController.instance.playerState.lives--;
                if (PersistenceController.instance.playerState.lives == 0)
                {
                    SceneManager.LoadScene(Configuration.endAct1SceneName);
                }
            }
            keepScore(evidence._itemValue);
            _evidenceCount++;

        }
        else if (godhelpme.GetSelectedEntry() != 9999999)
        {
            keepScore(godhelpme.GetSelectedEntry());
        }
        else
        {
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
        txtBox.disableDialogueTap = false;
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        switch (order)
        {
            case 0:
                {
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
    }

}

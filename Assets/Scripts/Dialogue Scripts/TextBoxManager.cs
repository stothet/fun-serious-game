using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls the dialogue between and NPC and player interaction
/// </summary>
public class TextBoxManager : MonoBehaviour
{

    public bool dialogBoxActive;

    public GameObject textBox;

    public Text dialogueText;
    public Image _person;
    public Text _name;

    public TextAsset txtFile;
    public string[] txtLines;
    public string[] txtLine;

    public int currentLine;
    public int endLine;
	public bool notNPC;
    public bool disableDialogueTap;

    public PlayerController player;
    public NPCController NPC;
    public TrialScript trialBox;

    public Sprite sprite1;
    public Sprite sprite2;
    public string _NPCname; // first method
    public string _currentNPCname; // second method
    public Journal journal;
    public GameObject controls;

    /// <summary>
    /// Initialise fields. Set up dialgoue box
    /// </summary>
    void Start()
    {
        trialBox = FindObjectOfType<TrialScript>();
        NPC = FindObjectOfType<NPCController>();
        journal = FindObjectOfType<Journal>();
		notNPC = true;
        // Load the initial dialogue txt file (if there is one)
        ReloadScript(txtFile);

        if (dialogBoxActive)
        {
            textBox.SetActive(true);
        }
        else
        {
            textBox.SetActive(false);
        }

    }

    /// <summary>
    /// Check if the dialogue should continue
    /// </summary>
    private void Update()
    {
        // Do nothing if no dialogue box active currently
        if (!dialogBoxActive)
        {
            return;
        }
        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown("space"))
        {
            if (!disableDialogueTap) {
                ContinueDialogue();
            }
        }
    }

    /// <summary>
    /// Proceed to the next line in a dialogue conversation in the dialogue box.
    /// </summary>
    public void ContinueDialogue()
    {

        if (PersistenceController.instance.dialogueState.currentLine.ContainsKey(NPC.name) &&
            PersistenceController.instance.dialogueState.firstTalk[NPC.name] == true)
        {
            PersistenceController.instance.dialogueState.firstTalk[NPC.name] = false;
            currentLine = PersistenceController.instance.dialogueState.currentLine[NPC.name];
        }

        if (currentLine <= endLine)
        {
            txtLine = new string[2];
            string s = txtLines[currentLine];
            txtLine = (txtLines[currentLine].Split(':'));

            bool isTransition = false;
            if (txtLine[0].Equals(Configuration.changeScenePrompt))
            {
                isTransition = true;
                PersistenceController.instance.dialogueState.firstTalk[NPC.name] = true;
                PersistenceController.instance.dialogueState.currentLine[NPC.name] = currentLine + 1;
                SceneManager.LoadScene(Configuration.minigameSceneName);
            }

            if (!isTransition)
            {
                dialogueText.text = txtLine[1];
                _currentNPCname = txtLine[0];
            }

        }
        else
        {
            currentLine = 0;
            if (trialBox.evidenceRequired.Equals("finished"))
            {
                SceneManager.LoadScene(Configuration.endAct1SceneName);
            }
            if (trialBox.presentEvidenceNow)
            {
                this.disableDialogueTap = true;
                return;
            }
            DisableDialogueBox();
            NPC.GiveEvidence(player);
            // Update the journal if it hasn't already for NPC info.
			if ((PersistenceController.instance.dialogueState.givenEvidenceRequiringTalk.ContainsKey(NPC.name) &&
				PersistenceController.instance.dialogueState.givenEvidenceRequiringTalk[NPC.name] == true)
            && (!PersistenceController.instance.dialogueState.givenJournalUpdateEvidenceRequiringTalk.ContainsKey(NPC.name) ||
                PersistenceController.instance.dialogueState.givenJournalUpdateEvidenceRequiringTalk[NPC.name] == false))
            {
                NPC.UpdateJournalSpecialEvidence(journal);
            }
            else
            {
                NPC.UpdateJournal(journal);
            }
            return;
        }

        currentLine += 1;

        if (_currentNPCname.Equals("Erin"))
        {
            _person.GetComponent<Image>().sprite = sprite1;
            _name.text = "Erin";
        }
        else
        {
            _person.GetComponent<Image>().sprite = sprite2;
            _name.text = _NPCname;
        }
    }
    /// <summary>
    /// Display the dialogue box
    /// </summary>
    public void ShowDialogueBox()
    {
        NPC.currentlyTalking = true;
        textBox.SetActive(true);
        dialogBoxActive = true;
        player.canMove = false;
        controls.SetActive(false);
    }
    /// <summary>
    /// Disables the dialogue box
    /// </summary>
    public void DisableDialogueBox()
    {
        NPC.currentlyTalking = false;
        textBox.SetActive(false);
        dialogBoxActive = false;
        player.canMove = true;
        controls.SetActive(true);
    }

    /// <summary>
    /// Identifies the talking NPC by setting the local NPC field.
    /// </summary>
    /// <param name="npc">Npc.</param>
    public void IdentifyNPC(NPCController npc)
    {
        NPC = npc;
    }

    /// <summary>
    ///  Load the script's info into local variables and show the dialog. Only loads if it hasn't already been before.
    /// </summary>
    /// <param name="script"></param>
    public void ReloadScript(TextAsset script)
    {
        // Return if script is null
        if (script == null)
        {
            return;
        }

        // If it's a new script, load it locally. Else just skip this and show dialogue box immediately.
        if (script != txtFile)
        {
            txtLines = new string[1];
            txtLines = (script.text.Split('\n'));

            // Set the end of the dialogue lines
            endLine = txtLines.Length - 1;
            txtFile = script;

            currentLine = 0;
        }

        // Show the dialogue box
        ShowDialogueBox();
    }
    /// <summary>
    /// Set the sprite of the dialogue box
    /// </summary>
    /// <param name="s"> Sprite for the dialogue box </param>
    public void setSprite(Sprite s)
    {
        sprite2 = s;
    }
    /// <summary>
    /// Set the name of the name of the NPC being interacted with
    /// </summary>
    /// <param name="name"> Name of the name </param>
    public void setNPCname(string name)
    {
        _NPCname = name;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public int endLine;
    public bool toggle = true;


    public PlayerController player;
    public NPCController NPC;

    public Sprite sprite1;
    public Sprite sprite2;
    public string _NPCname; //first method
    public string _currentNPCname; //second method

    public Journal journal;

    // Use this for initialization
    void Start()
    {
        //NPC = FindObjectOfType<NPCController>();
        NPC = PersistenceController.JournalState.NPC;
       // Debug.Log("1 . NPC" + PersistenceController.JournalState.NPC._name);
        journal = FindObjectOfType<Journal>();

        // Load the initial dialogue txt file (if there is one)
        ReloadScript(txtFile);

        if (dialogBoxActive)
        {
            textBox.SetActive(true);
        }
        else if (PersistenceController.DialogueState.shouldStartConversation)
        {
            textBox.SetActive(true);
            ContinueDialogue();
        }
        else
        {
            textBox.SetActive(false);
        }

    }

    private void Update()
    {
        // Do nothing if no dialogue box active currently
        if (!dialogBoxActive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)|| PersistenceController.DialogueState.shouldStartConversation)
        {
            PersistenceController.DialogueState.shouldStartConversation = false;
            ContinueDialogue();
        }
    }

    /// <summary>
    /// Proceed to the next line in a dialogue conversation in the dialogue box.
    /// </summary>
    public void ContinueDialogue()
    {
        int currentLine = PersistenceController.DialogueState.currentLine;
        if (currentLine <= endLine)
        {
            txtLine = new string[2];
            string s = txtLines[currentLine];
            txtLine = (txtLines[currentLine].Split(':'));

            bool isTransition = false;
            if (txtLine[0].Equals(Configuration.ChangeScenePrompt))
            {
                isTransition = true;
                PersistenceController.DialogueState.shouldStartConversation = true;
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
            DisableDialogueBox();
            PersistenceController.DialogueState.currentLine = 0;
            return;
        }

        PersistenceController.DialogueState.currentLine += 1;

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

    public void ShowDialogueBox()
    {
        NPC.currentlyTalking = true;
        textBox.SetActive(true);
        dialogBoxActive = true;
        player.canMove = false;
    }

    public void DisableDialogueBox()
    {
        NPC.currentlyTalking = false;
        textBox.SetActive(false);
        dialogBoxActive = false;
        player.canMove = true;


        // Update the journal if it hasn't already for NPC info.
        NPC.UpdateJournal(journal);

        NPC.GiveEvidence(player);
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
        }

        // Show the dialogue box
        ShowDialogueBox();
    }

    public void setSprite(Sprite s)
    {
        sprite2 = s;
    }

    public void setNPCname(string name)
    {
        _NPCname = name;
    }
}

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

    public int endLine;


    public TextAsset txtFile;
    public string[] txtLines;
    public string[] txtLine;

    public bool toggle = true;


    public PlayerController player;

    public Sprite sprite1;
    public Sprite sprite2;
    public string _NPCname; //first method
    public string _currentNPCname; //second method

    public Journal journal;

    // Use this for initialization
    void Start()
    {
        // Debug.Log("1 . NPC" + PersistenceController.JournalState.NPC._name);
        journal = FindObjectOfType<Journal>();

        // Load the initial dialogue txt file (if there is one)
        ReloadScript(txtFile);

        if (PersistenceController.DialogueState.shouldStartConversation)
        {
            Debug.Log("Continuing dialog");
            Debug.Log("NPC is " + PersistenceController.JournalState.NPC);
            Debug.Log("Journal is " + PersistenceController.JournalState.journal);
            Debug.Log("XD current line is " + PersistenceController.DialogueState.currentLine);
            PersistenceController.DialogueState.shouldStartConversation = false;
            textBox.SetActive(true);
            ContinueDialogue();
        }
        else if (dialogBoxActive)
        {
            textBox.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            ContinueDialogue();
        }
        
    }

    /// <summary>
    /// Proceed to the next line in a dialogue conversation in the dialogue box.
    /// </summary>
    public void ContinueDialogue()
    {
        Debug.Log("NPC continuing: " + PersistenceController.JournalState.NPC);
        int currentLine = PersistenceController.DialogueState.currentLine;
        if (currentLine <= endLine)
        {
            txtLine = new string[2];
            string s = txtLines[currentLine];
            txtLine = (txtLines[currentLine].Split(':'));

            bool isTransition = false;
            if (txtLine[0].Equals(Configuration.changeScenePrompt))
            {
                isTransition = true;
                Debug.Log("NPC is set to: " + PersistenceController.JournalState.NPC);
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
            PersistenceController.DialogueState.currentLine = 0;
            DisableDialogueBox();
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
        PersistenceController.JournalState.NPC.currentlyTalking = true;
        textBox.SetActive(true);
        dialogBoxActive = true;
        player.canMove = false;
    }

    public void DisableDialogueBox()
    {
        PersistenceController.JournalState.NPC.currentlyTalking = false;
        textBox.SetActive(false);
        dialogBoxActive = false;
        player.canMove = true;


        // Update the journal if it hasn't already for NPC info.
        PersistenceController.JournalState.NPC.UpdateJournal(journal);

        PersistenceController.JournalState.NPC.GiveEvidence(player);
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

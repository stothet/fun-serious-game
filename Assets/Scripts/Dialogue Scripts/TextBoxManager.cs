using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public bool dialogBoxActive;

    public GameObject textBox;

    public Text dialogueText;
	public Image _person;

    public TextAsset txtFile;
    public string[] txtLines;

    public int currentLine;
    public int endLine;
	public int toggle=0;

    public PlayerController player;
    public NPCController NPC;

	public Sprite sprite1;
	public Sprite sprite2;

    // Use this for initialization
    void Start()
    {
        //player = FindObjectOfType<PlayerController>();
        NPC = FindObjectOfType<NPCController>();

        // Load the initial dialogue txt file (if there is one)
        ReloadScript(txtFile);

        if (dialogBoxActive)
        {
            ShowDialogueBox();
        }
        else
        {
            DisableDialogueBox();
        }

    }

    private void Update()
    {
        // Do nothing if no dialogue box active currently
        if (!dialogBoxActive)
        {
            return;
        }

        if (currentLine <= endLine)
        {
            dialogueText.text = txtLines[currentLine];
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;


			if (toggle == 0) {
				toggle = 1;
				_person.GetComponent<Image>().sprite = sprite1;
			} 
			else {
				toggle = 0;
				_person.GetComponent<Image>().sprite = sprite2;
			}
        }

        if (currentLine > endLine)
        {
            DisableDialogueBox();
            currentLine = 0;
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
}

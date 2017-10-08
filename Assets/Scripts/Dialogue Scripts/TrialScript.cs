using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrialScript : MonoBehaviour
{
	public bool trialActive;
	public Text question;
	public TextBoxManager txtBox;

	public Button option1;
	public Button option2;
	public Button option3;

	public Button choice1;
	public Button choice2;

	public Item evidence;

	public TextAsset introFile;
	public TextAsset prelude;
	public TextAsset bruceIsFree;
	public TextAsset goBack;
	public TextAsset youLose;

	public string[] txtLines;
	public string[] txtLine;
	public int currentLine;

	public PlayerController player;
	public NPCController NPC;

	//panel and button would handle this script

	// Use this for initialization
	void Start ()
	{
		NPC = FindObjectOfType<NPCController>();
		txtBox = FindObjectOfType<TextBoxManager>();

		option1.gameObject.SetActive (false);
		option2.gameObject.SetActive (false);
		option3.gameObject.SetActive (false);

		Button choice1Button = GetComponent<Button>();
		Button choice2Button = GetComponent<Button>();

		option1 = GetComponent<Button>();
		option2 = GetComponent<Button>();
		option3 = GetComponent<Button>();

		choice1.gameObject.SetActive (false);
		choice2.gameObject.SetActive (false);


	}

	// Update is called once per frame
	void Update ()
	{

		//update score
	}

	//affects chances
	void Outcome(){

	}

	//called when evidence is selected
	void keepScore(){
	}

	//reloads generic dialogues
	public void trialDialogue(int caseSwitch){

		switch (caseSwitch)
		{
		case 0:
			
			{
				txtBox.ReloadScript(introFile);

				choice1.gameObject.SetActive (true);
				choice2.gameObject.SetActive (true);

				break;
			}

		case 1:

			{
				txtBox.ContinueDialogue ();
				txtBox.ReloadScript(prelude);
				//txtBox.dialogBoxActive = true;
				choice1.gameObject.SetActive (false);
				choice2.gameObject.SetActive (false);
				break;
			}

		default:
			{
			break;
			}

		}

	}

	//select item from inventory
	//calls keepScore to change score given the item value
	void selectObjectEvidence(){
	}

	//picks option from the buttons
	//calls keepScore to change score given value (not implemented yet)
	public void CheckClick(Button b)
	{
		print (choice1);
		//string text = b.GetComponent<Text>().ToString();

		if (Button.ReferenceEquals (choice1, b) || Button.ReferenceEquals (choice2, b)) {
			trialDialogue (1);
		}


	}

	void getChoice(){
		
	}

}


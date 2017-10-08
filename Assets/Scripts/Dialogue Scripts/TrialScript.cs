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

	public Item evidence;

	public TextAsset introFile;
	public TextAsset prelude;
	public TextAsset guilty;
	public TextAsset notGuilty;
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

		option1.GetComponent<Text>() = "First Option";
		option2.GetComponent<Text>() = "2 Option";
		option3.GetComponent<Text>() = "3 Option";

		Button btn1 = option1.GetComponent<Button>();
		Button btn2 = option2.GetComponent<Button>();
		Button btn3 = option3.GetComponent<Button>();

		btn1.onClick.AddListener(TaskOnClick(option1));
		btn2.onClick.AddListener(TaskOnClick);
		btn3.onClick.AddListener(TaskOnClick);

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
			txtBox.ReloadScript(introFile);
			break;

		case 1:
			txtBox.ReloadScript(prelude);
			option1.gameObject.SetActive (true);
			option2.gameObject.SetActive (true);
			option3.gameObject.SetActive (true);
			break;

		default:
			break;
		}

	}

	//select item from inventory
	//calls keepScore to change score given the item value
	void selectObjectEvidence(){
	}

	//picks option from the buttons
	//calls keepScore to change score given value (not implemented yet)
	void TaskOnClick(Button b)
	{
		string text = b.GetComponent<Text> ();
	}

}


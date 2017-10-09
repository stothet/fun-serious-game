using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrialScript : MonoBehaviour
{
	public bool trialActive;
	public Text question;
	public TextBoxManager txtBox;

	public GameObject scoreKeeper;
	public Text _score;

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

	public static int cumulative=0;

	public PlayerController player;
	public NPCController NPC;

	//panel and button would handle this script

	// Use this for initialization
	void Start ()
	{
		NPC = FindObjectOfType<NPCController>();
		txtBox = FindObjectOfType<TextBoxManager>();

		scoreKeeper.SetActive (true);

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
		
	}

	//affects chances
	void Outcome(){
		if(cumulative > 0){
			trialDialogue (2);
			//SceneManager.LoadScene(3);
			//You win end game screen
		}else if(cumulative == 0){
			trialDialogue (3);
			//PlayerController.subtractLife();
		}else{
			trialDialogue (4);
			//SceneManager.LoadScene(3);
			//you lose end game screen
		}
	}

	//called when evidence is selected
	void keepScore(int evidenceValue){
		cumulative += evidenceValue;
		_score.text = cumulative.ToString ();
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
				txtBox.ReloadScript(prelude);
				txtBox.ContinueDialogue ();
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

	}

	//select item from inventory
	//calls keepScore to change score given the item value
	void selectObjectEvidence(){
	}

	//picks option from the buttons
	//calls keepScore to change score given value (not implemented yet)
	public void CheckClick(Button b)
	{

		if (Button.ReferenceEquals (choice1, b) || Button.ReferenceEquals (choice2, b)) {
			trialDialogue (1);
		}
		else if(Button.ReferenceEquals (option1, b)){
			//Billy
			keepScore(-5);
		}
		else if(Button.ReferenceEquals (option2, b)){
			//Jimmy
			keepScore(-5);
		}
		else if(Button.ReferenceEquals (option3, b)){
			//Rita
			keepScore(5);
		}

	}

}


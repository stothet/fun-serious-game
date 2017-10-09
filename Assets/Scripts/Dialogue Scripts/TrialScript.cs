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
	public GameObject livesKeeper;
	public Text _score;
	int _evidenceCount=0;

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

	private Inventory inventory;
	private Button submitButton;

	//panel and button would handle this script

	// Use this for initialization
	void Start ()
	{
		NPC = FindObjectOfType<NPCController>();
		txtBox = FindObjectOfType<TextBoxManager>();
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		submitButton = GameObject.FindGameObjectWithTag("SubmitButton").GetComponent<Button>();

		submitButton.gameObject.SetActive(false);

		scoreKeeper.SetActive (false);

		option1.gameObject.SetActive (false);
		option2.gameObject.SetActive (false);
		option3.gameObject.SetActive (false);

		choice1.gameObject.SetActive (false);
		choice2.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update ()
	{
		if(_evidenceCount == 2){
			Outcome ();
		}
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
			livesKeeper.SetActive (true);
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

				scoreKeeper.SetActive (true);
				livesKeeper.SetActive (false);

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

				option1.gameObject.SetActive (true);
				option2.gameObject.SetActive (true);
				option3.gameObject.SetActive (true);

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
	public void SelectObjectEvidence(){
		evidence = inventory.GetSelectedItem();

		if (evidence != null)
		{
			Debug.Log("Evidence chosen: " + evidence._itemName);
			keepScore(evidence._itemValue);
			_evidenceCount++;

		} else
		{
			// Do nothing as nothing is selected
			return;
		}
	}

	//picks option from the buttons
	//calls keepScore to change score given value (not implemented yet)
	public void CheckClick(Button b)
	{

		if (Button.ReferenceEquals (choice1, b) || Button.ReferenceEquals (choice2, b)) {
			trialDialogue (1);
			submitButton.gameObject.SetActive (true);
		} else {
			if (Button.ReferenceEquals (option1, b)) {
				//Billy
				keepScore (-5);
			} else if (Button.ReferenceEquals (option2, b)) {
				//Jimmy
				keepScore (-5);
			} else if (Button.ReferenceEquals (option3, b)) {
				//Rita
				keepScore (5);
			}
			_evidenceCount++;
		}

	}

}


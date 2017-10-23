using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
/// <summary>
/// This class controls how NCPs behave and interact with the player
/// </summary>
/// <remarks>
/// Gives the appropriate evidence and items to player
/// </remarks>
public class NPCController : MonoBehaviour {

	public bool firstTimeTalk;

	public TextAsset initialDialogueFile;
	public TextAsset defaultDialogueFile;
	public TextAsset characterDescription;
    public TextAsset evidenceTriggerDialogueFile;
    public TextAsset characterDescription2;
    public string requiredItem;

    public TextBoxManager txtBox;
	public TrialScript trialBox;

	public Sprite _sprite;
	public string _name;
	public int order=0;
	private SpriteRenderer sr;

	public bool currentlyTalking;


	public bool journalUpdated;

	public bool givenEvidence;
	public string evidenceName;

	// Make player auto-talk to NPC in a cutscene
	public bool autoTalk;

	/// <summary>
	/// Initialise fields
	/// </summary>
	void Start()
	{
		txtBox = FindObjectOfType<TextBoxManager>();
		firstTimeTalk = true;
		currentlyTalking = false;
		journalUpdated = false;
		givenEvidence = false;
		autoTalk = false;
        if (!PersistenceController.instance.dialogueState.firstTalk.ContainsKey(name)){
			PersistenceController.instance.dialogueState.firstTalk.Add(name, true);
			PersistenceController.instance.dialogueState.givenEvidence.Add(name, false);
			PersistenceController.instance.dialogueState.journalUpdated.Add(name, false);

		}
	}

	// Update is called once per frame
	void Update()
	{
		sr = GetComponent<SpriteRenderer>();
		_sprite = sr.sprite;
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll (ray, Mathf.Infinity);
			foreach (var hit in hits) {
				Debug.Log (hit.collider.name);
				//Debug.Log ("SR: "+sr.gameObject.transform.position);
				//Debug.Log ("Hit: "+hit.point);
				Vector2 pointHit = hit.point;
				Vector3 spritePoint = sr.gameObject.transform.position;
				if (hit.collider.CompareTag("NPC") || hit.collider.CompareTag("Principal")) {
					if (pointHit.x > spritePoint.x - 0.5 && pointHit.x < spritePoint.x + 0.5) {
						if (pointHit.y > spritePoint.y - 0.5 && pointHit.y < spritePoint.y + 0.5) {
							Debug.Log ("This is text: "+txtBox.dialogueText.text);
							startConversation ();

						}
					}
				}
			}
		}
		//			RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
		/*
		Debug.Log (hit.point);
			Debug.Log ("The clicked point: " + sr.gameObject.transform.position);
			if (hit.point.x > -33 && hit.point.x < -29 && hit.point.y > -6 && hit.point.y < -2) {
				Debug.Log ("Principal clicked");
			} else if (hit.point.x > 17 && hit.point.x < 21 && hit.point.y > -46 && hit.point.y < -42) {
				Debug.Log ("Jimmy clicked");
			} else if (hit.point.x > -57 && hit.point.x < -53 && hit.point.y > -8 && hit.point.y < -4) {
				Debug.Log ("LunchLady clicked");
			} else if (hit.point.x > -35 && hit.point.x < -31 && hit.point.y > -25 && hit.point.y < -21) {
				Debug.Log ("ScienceGuy clicked");
			}

		}					
		*/
	}

	private void startConversation(){
		//Debug.Log ("Hello");
		//txtBox.notNPC = false;
		//sr = GetComponent<SpriteRenderer>();
		//PersistenceController.instance.journalState.NPC = this;
		//_sprite = sr.sprite;
		//print(getSprite());
		txtBox.setSprite(getSprite());
		txtBox.setNPCname(_name);
		Debug.Log ("Hello is the npc name right?"+txtBox._NPCname);
		// When the player presses Space to talk to the NPC
		//if (Input.GetKeyDown(KeyCode.Return))
		//{
		if (!currentlyTalking)
		{
			currentlyTalking = true;
			txtBox.IdentifyNPC (this);
			Debug.Log("Name of NPC: "+name);
            bool isEvidenceTalk = false;
            Debug.Log(requiredItem + " ITEM1");
            if (requiredItem != null)
            {
                Debug.Log(requiredItem + " ITEM2");
                if (PlayerHasRequiredItem())
                {
                    Debug.Log(requiredItem + " ITEM3");
                    if (!PersistenceController.instance.dialogueState.givenEvidenceRequiringTalk.ContainsKey(name) || PersistenceController.instance.dialogueState.givenEvidenceRequiringTalk[name] == false)
                    {
                        Debug.Log(requiredItem + " ITEM4");
                        isEvidenceTalk = true;
						PersistenceController.instance.dialogueState.givenEvidenceRequiringTalk.Add (name, true);
            
                        txtBox.ReloadScript(evidenceTriggerDialogueFile);
                        txtBox.ContinueDialogue();
                    }
                    

                }
            }
            if (!isEvidenceTalk)
            {
                if (PersistenceController.instance.dialogueState.firstTalk[name])
                {
                    txtBox.ReloadScript(initialDialogueFile);
                    /*if (PersistenceController.instance.dialogueState.currentLine.ContainsKey(name) &&
                        PersistenceController.instance.dialogueState.firstTalk[name] == true)
                    {
                        Debug.Log ("Hello?");
                    }
                    /*else
                    {*/
                    txtBox.ContinueDialogue();
                    PersistenceController.instance.dialogueState.firstTalk[name] = false;
                    //}


                    if (autoTalk)
                    {
                        txtBox.ContinueDialogue();
                    }

                }
                else
                {
                    if (_name.Equals("Wilson"))
                    {
                        trialBox = FindObjectOfType<TrialScript>();
                        trialBox.trialDialogue(-1);
                        trialBox.gameObject.SetActive(true);

                    }
                    else
                    {
                        txtBox.ReloadScript(defaultDialogueFile);
                        txtBox.ContinueDialogue();
                    }
                }
            }
           
		} else
		{
			return;
		}
		PersistenceController.instance.dialogueState.autoTalk = false;

	}

	/// <summary>
	/// Updates the journal based on the dialogue given
	/// </summary>
	/// <param name="journal"> The journal to be updated </param>
	public void UpdateJournal(Journal journal)
	{
		if (!PersistenceController.instance.dialogueState.journalUpdated[name])
		{
			journal.putJournalEntry(characterDescription.text);
			PersistenceController.instance.dialogueState.journalUpdated[name] = true;
		}
	}

    /// <summary>
	/// Updates the journal based on the dialogue given
	/// </summary>
	/// <param name="journal"> The journal to be updated </param>
	public void UpdateJournalSpecialEvidence(Journal journal)
    {
        Debug.Log("Updating with special evidence");

		if (!PersistenceController.instance.dialogueState.givenJournalUpdateEvidenceRequiringTalk.ContainsKey(name) ||
			PersistenceController.instance.dialogueState.givenJournalUpdateEvidenceRequiringTalk[name] == false)
        {
            journal.putJournalEntry(characterDescription2.text);
            PersistenceController.instance.dialogueState.givenJournalUpdateEvidenceRequiringTalk[name] = true;
            Debug.Log("Special updated");

        }
    }



    /// <summary>
    /// Gives the evidence item to the player
    /// </summary>
    /// <param name="player"> The player to give the evidence to </param>
    public void GiveEvidence(PlayerController player)
	{
		Debug.Log(name);
		if (!PersistenceController.instance.dialogueState.givenEvidence[name])
		{
			if (evidenceName != null && evidenceName != "")
			{
				player.addToInventory(evidenceName);
				PersistenceController.instance.dialogueState.givenEvidence[name] = true;
			}
		}
	}



    void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.CompareTag("Player") && (PersistenceController.instance.dialogueState.autoTalk)){
			//txtBox.notNPC = false;
			sr = GetComponent<SpriteRenderer>();
			//PersistenceController.instance.journalState.NPC = this;
			_sprite = sr.sprite;
			print(getSprite());
			txtBox.setSprite(getSprite());
			txtBox.setNPCname(_name);
            // When the player presses Space to talk to the NPC
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            Debug.Log("ACTUALly DOING SOMETHING");
			if (!currentlyTalking)
			{
				currentlyTalking = true;
				txtBox.IdentifyNPC (this);
				Debug.Log(name);

                if (PersistenceController.instance.dialogueState.firstTalk[name])
                {
                    txtBox.ReloadScript(initialDialogueFile);
                    if (PersistenceController.instance.dialogueState.currentLine.ContainsKey(name) &&
                        PersistenceController.instance.dialogueState.firstTalk[name] == true)
                    {

                    }
                    else
                    {
                        PersistenceController.instance.dialogueState.firstTalk[name] = false;
                    }


                    if (autoTalk)
                    {
                        txtBox.ContinueDialogue();
                    }

                }
                else
                {
                    if (_name.Equals("Wilson"))
                    {
                        trialBox = FindObjectOfType<TrialScript>();
                        trialBox.trialDialogue(-1);
                        trialBox.gameObject.SetActive(true);

                    }
                    else
                    {
                        txtBox.ReloadScript(defaultDialogueFile);
                    }
                }
                
                
			} else
			{
				return;
			}
			PersistenceController.instance.dialogueState.autoTalk = false;

		}
	}
	/// <summary>
	/// Gets the sprite of the NPC
	/// </summary>
	/// <returns> Sprite of the NPC </returns>
	public Sprite getSprite(){
		return _sprite;
	}
	/// <summary>
	/// Sets the order
	/// </summary>
	/// <param name="_order"> The order number </param>
	public void setOrder(int _order){
		order = _order;
	}

    public bool PlayerHasRequiredItem()
    {
        List<string> localDB = PersistenceController.instance.inventoryState.database;
        return localDB.Contains(requiredItem);
    }
}
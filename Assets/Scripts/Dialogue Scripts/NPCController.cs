using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    public bool firstTimeTalk;

    public TextAsset initialDialogueFile;
    public TextAsset defaultDialogueFile;
	public TextAsset characterDescription;

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

    // Use this for initialization
    void Start()
    {
        txtBox = FindObjectOfType<TextBoxManager>();
        firstTimeTalk = true;
        currentlyTalking = false;
		journalUpdated = false;
        givenEvidence = false;
        autoTalk = false;
        if (!PersistenceController.DialogueState.firstTalk.ContainsKey(name)){
            PersistenceController.DialogueState.firstTalk.Add(name, true);
            PersistenceController.DialogueState.givenEvidence.Add(name, false);
            PersistenceController.DialogueState.journalUpdated.Add(name, false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void UpdateJournal(Journal journal)
	{
		if (!PersistenceController.DialogueState.journalUpdated[name])
		{
            journal.putJournalEntry(characterDescription.text);
            PersistenceController.DialogueState.journalUpdated[name] = true;
        }
	}

    public void GiveEvidence(PlayerController player)
    {
        Debug.Log(name);
        if (!PersistenceController.DialogueState.givenEvidence[name])
        {
            player.addToInventory(evidenceName);
            PersistenceController.DialogueState.givenEvidence[name] = true;
        }
    }

    /// <summary>
    /// Triggers every frame that the player is in contact with NPC. Used to trigger conversation.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {

        // When the player comes in contact with the NPC object
		if (other.gameObject.CompareTag("Player") && (PersistenceController.DialogueState.autoTalk || Input.GetKeyDown(KeyCode.Space)))
        {
			sr = GetComponent<SpriteRenderer>();
            PersistenceController.JournalState.NPC = this;
			_sprite = sr.sprite;
            print(getSprite());
            txtBox.setSprite(getSprite());
            txtBox.setNPCname(_name);
            // When the player presses Space to talk to the NPC
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            if (!currentlyTalking)
            {
                currentlyTalking = true;
				txtBox.IdentifyNPC (this);
                Debug.Log(name);
                if (PersistenceController.DialogueState.firstTalk[name])
                {
                    txtBox.ReloadScript(initialDialogueFile);
                    PersistenceController.DialogueState.firstTalk[name] = false;

                    if (autoTalk)
                    {
                        txtBox.ContinueDialogue();
                    }

                }
                else
                {
					if(_name.Equals("Wilson")){
						trialBox = FindObjectOfType<TrialScript>();
						trialBox.trialDialogue(order);
						trialBox.gameObject.SetActive(true);

					}
					else{
						txtBox.ReloadScript(defaultDialogueFile);
					}
                }
            } else
            {
                return;
            }
            PersistenceController.DialogueState.autoTalk = false;
        }
    }

    public Sprite getSprite(){
        return _sprite;
    }

	public void setOrder(int _order){
		order = _order;
	}
}

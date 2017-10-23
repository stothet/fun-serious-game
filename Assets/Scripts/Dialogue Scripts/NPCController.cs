using UnityEngine;
using System.Collections;

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
    public TextAsset evidenceTriggerDialogueFile;
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

    /// <summary>
    /// Triggers every frame that the player is in contact with NPC. Used to trigger conversation.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {

        // When the player comes in contact with the NPC object
		if (other.gameObject.CompareTag("Player") && (PersistenceController.instance.dialogueState.autoTalk || ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown("space"))))
        {
			sr = GetComponent<SpriteRenderer>();
            //PersistenceController.instance.journalState.NPC = this;
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
					if(_name.Equals("Wilson")){
						trialBox = FindObjectOfType<TrialScript>();
						trialBox.trialDialogue(-1);
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
}

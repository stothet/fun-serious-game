using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    public bool firstTimeTalk;

    public TextAsset initialDialogueFile;
    public TextAsset defaultDialogueFile;
	public TextAsset characterDescription;

    public Sprite _sprite;
    public string _name;
    private SpriteRenderer sr;

    public bool currentlyTalking;

	public bool journalUpdated;

    public bool givenEvidence;
    public string evidenceName;

    // Make player auto-talk to NPC in a cutscene
    public bool autoTalk;


    void Awake()
    {
        DontDestroyChildOnLoad(gameObject);
    }
    public static void DontDestroyChildOnLoad(GameObject child)
    {
        Transform parentTransform = child.transform;

        // If this object doesn't have a parent then its the root transform.
        while (parentTransform.parent != null)
        {
            // Keep going up the chain.
            parentTransform = parentTransform.parent;
        }
        GameObject.DontDestroyOnLoad(parentTransform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        PersistenceController.DialogueState.textBox = FindObjectOfType<TextBoxManager>();
        firstTimeTalk = true;
        currentlyTalking = false;
		journalUpdated = false;
        givenEvidence = false;
        autoTalk = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	public void UpdateJournal(Journal journal)
	{
		if (!journalUpdated) 
		{
            journal.putJournalEntry(characterDescription.text);
			journalUpdated = true;
		}
	}

    public void GiveEvidence(PlayerController player)
    {
        Debug.Log(name);
        if (!givenEvidence)
        {
            player.addToInventory(evidenceName);
            givenEvidence = true;
        }
    }

    /// <summary>
    /// Triggers every frame that the player is in contact with NPC. Used to trigger conversation.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        
        // When the player comes in contact with the NPC object
		if (other.gameObject.CompareTag("Player") && (autoTalk || Input.GetKeyDown(KeyCode.Space)))
        {
			
            Debug.Log("Setting NPC state to: " + this);
            PersistenceController.JournalState.NPC = this;
            setSprite();
		
            // When the player presses Space to talk to the NPC
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            if (!currentlyTalking)
            {
                currentlyTalking = true;
                PersistenceController.JournalState.NPC = this;
            
                if (firstTimeTalk)
                {
                    PersistenceController.DialogueState.textBox.ReloadScript(initialDialogueFile);
                    firstTimeTalk = false;

                    if (autoTalk)
                    {
                        PersistenceController.DialogueState.textBox.ContinueDialogue();
                    }

                }
                else
                {
                    PersistenceController.DialogueState.textBox.ReloadScript(defaultDialogueFile);
                }
            } else
            {
                return;
            }
            autoTalk = false;
        }
    }

    public Sprite getSprite(){
        return _sprite;
    }

    public void setSprite()
    {
        sr = GetComponent<SpriteRenderer>();
        _sprite = sr.sprite;
        print(getSprite());
        PersistenceController.DialogueState.textBox.setSprite(getSprite());
        PersistenceController.DialogueState.textBox.setNPCname(_name);
    }
}

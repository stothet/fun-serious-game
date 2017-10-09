using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    public bool firstTimeTalk;

    public TextAsset initialDialogueFile;
    public TextAsset defaultDialogueFile;
	public TextAsset characterDescription;

    public TextBoxManager txtBox;

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
        txtBox = FindObjectOfType<TextBoxManager>();
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
			sr = GetComponent<SpriteRenderer>();
            Debug.Log("Setting NPC state to: " + this);
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
                PersistenceController.JournalState.NPC = this;
            
                if (firstTimeTalk)
                {
                    txtBox.ReloadScript(initialDialogueFile);
                    firstTimeTalk = false;

                    if (autoTalk)
                    {
                        txtBox.ContinueDialogue();
                    }

                }
                else
                {
                    txtBox.ReloadScript(defaultDialogueFile);
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
}

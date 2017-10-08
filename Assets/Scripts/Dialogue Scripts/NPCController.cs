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

    // Use this for initialization
    void Start()
    {
        txtBox = FindObjectOfType<TextBoxManager>();
        firstTimeTalk = true;
        currentlyTalking = false;
		journalUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void UpdateJournal(Journal journal)
	{
		if (!journalUpdated) 
		{
			journal.putJournalEntry (characterDescription.text);
			journalUpdated = true;
		}
	}

    /// <summary>
    /// Triggers every frame playe is in contact with NPC. Used to trigger conversation.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        
        // When the player comes in contact with the NPC object
		if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {

			sr = GetComponent<SpriteRenderer>();

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
                if (firstTimeTalk)
                {
                    txtBox.ReloadScript(initialDialogueFile);
                    firstTimeTalk = false;
                }
                else
                {
                    txtBox.ReloadScript(defaultDialogueFile);
                }
            } else
            {
                return;
            }
        }
    }

    public Sprite getSprite(){
        return _sprite;
    }
}

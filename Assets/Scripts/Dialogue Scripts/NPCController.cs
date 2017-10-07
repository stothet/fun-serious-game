using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    public bool firstTimeTalk;

    public TextAsset initialDialogueFile;
    public TextAsset defaultDialogueFile;

    public TextBoxManager txtBox;

    public bool currentlyTalking;

    public bool destroyWhenActivated;

    // Use this for initialization
    void Start()
    {
        txtBox = FindObjectOfType<TextBoxManager>();
        firstTimeTalk = true;
        currentlyTalking = false;
    }

    // Update is called once per frame
    void Update()
    {

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
            // When the player presses Space to talk to the NPC
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            if (!currentlyTalking)
            {
                currentlyTalking = true;
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

                
            //}

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}

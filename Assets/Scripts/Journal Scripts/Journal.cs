using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Handles the journal entries into the journal
/// </summary>
public class Journal : MonoBehaviour {
    public Text journalEntry;
	public int journalEntryValue;
    public GameObject JournalSlot;
    private Text selectedText;
    public List<Button> _entries = new List<Button>();
    Image journalTabImage;
	public int counter;
    public void Start()
    {	
		counter = 0;
		journalTabImage = GameObject.FindGameObjectWithTag("JournalTab").GetComponent<Image>();
        for(int i = 0; i<PersistenceController.instance.journalState.journal.Count; i++)
        {
            putJournalEntry(PersistenceController.instance.journalState.journal[i]);
        }

    }

    /// <summary>
    /// Adds a new journal slot to the journal interface, populated with the desired text.
    /// </summary>
    /// <param name="txt">Text to be added to the journal slot entry.</param>
    public void putJournalEntry(string txt)
    {
		counter += 1;
        //if(PersistenceController.JournalState.journal)
        GameObject slot = GameObject.Instantiate(JournalSlot);
        slot.AddComponent<RectTransform>();
        slot.AddComponent<Button>();
        Button b = slot.GetComponentInChildren<Button>();
        b.onClick.AddListener(TaskOnClick);
        _entries.Add(b);
        Debug.Log("HERe1");
        journalEntry = slot.GetComponentInChildren<Text>();
        slot.transform.SetParent(this.gameObject.transform, false);
        journalEntry.text = txt;

		Journal jrnl = slot.GetComponent<Journal> (); //Get the journal object of the slot instance.
		jrnl.journalEntryValue = counter; //Set the journal entry value. Hardcoded as 6 as an example.
        if (!PersistenceController.instance.journalState.journal.Contains(txt))
        {
            PersistenceController.instance.journalState.journal.Add(txt);
			journalTabImage.sprite = Resources.Load<Sprite> ("Icons/JournalIconAlert");
        }
        //journalEntry.text = PersistenceController.JournalState.journal;
    }

    void TaskOnClick()
    {
        Debug.Log("HERe2");
        GameObject selectedSlot = EventSystem.current.currentSelectedGameObject;
		//Debug.Log (jrnl.journalEntryValue);
        //selectedText = selectedSlot.GetComponentInChildren<Text>();

    }

    /// <summary>
    /// Returns the currently selected item by the player.
    /// </summary>
    /// <returns></returns>
    public Text GetSelectedEntry()
    {
        return selectedText;
    }


}

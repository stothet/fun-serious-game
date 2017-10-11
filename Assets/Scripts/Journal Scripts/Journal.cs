using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Handles the journal entries into the journal
/// </summary>
public class Journal : MonoBehaviour {
    public Text journalEntry;
    public GameObject JournalSlot;
    public void Start()
    {
        //journalEntry.text = PersistenceController.JournalState.journal;
    }
    
    /// <summary>
    /// Adds a new journal slot to the journal interface, populated with the desired text.
    /// </summary>
    /// <param name="txt">Text to be added to the journal slot entry.</param>
    public void putJournalEntry(string txt)
    {
        GameObject slot = GameObject.Instantiate(JournalSlot);
        journalEntry = slot.GetComponentInChildren<Text>();
        slot.transform.SetParent(this.gameObject.transform, false);
        journalEntry.text = txt;
        //PersistenceController.JournalState.journal += txt;
        //journalEntry.text = PersistenceController.JournalState.journal;
    }
}

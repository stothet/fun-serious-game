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
        //if(PersistenceController.JournalState.journal)
        GameObject slot = GameObject.Instantiate(JournalSlot);
        journalEntry = slot.GetComponentInChildren<Text>();
        slot.transform.SetParent(this.gameObject.transform, false);
        journalEntry.text = txt;
        if (!PersistenceController.instance.journalState.journal.Contains(txt))
        {
            PersistenceController.instance.journalState.journal.Add(txt);
        }
        //journalEntry.text = PersistenceController.JournalState.journal;
    }
}

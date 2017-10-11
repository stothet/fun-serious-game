using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Handles the journal entries into the journal
/// </summary>
public class Journal : MonoBehaviour {
    public Text journal;

    public void Start()
    {
        journal.text = PersistenceController.instance.journalState.journal;
    }
    public void putJournalEntry(string txt)
    {
        PersistenceController.instance.journalState.journal += txt + "\n";
        journal.text = PersistenceController.instance.journalState.journal;
    }
}

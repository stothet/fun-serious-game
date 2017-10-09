using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Journal : MonoBehaviour {
    public Text journal;
    public void putJournalEntry(string txt)
    {
        PersistenceController.JournalState.journal += txt + "\n";
        journal.text = PersistenceController.JournalState.journal;
    }
}

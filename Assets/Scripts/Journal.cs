using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Journal : MonoBehaviour {
    public Text journal;

    public void putJournalEntry(string txt)
    {
        journal.text += txt + "\n";
    }
}

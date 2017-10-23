using System;
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
	public int journalEntryValue = 9999999;
	public GameObject JournalSlot;
	private Text selectedText;
	public List<Button> _entries = new List<Button>();
	Image journalTabImage;
	public JournalValues journalValues;
	public int _score;
	public void Start()
	{	
		journalTabImage = GameObject.FindGameObjectWithTag("JournalTab").GetComponent<Image>();
		journalValues = GameObject.FindGameObjectWithTag("JournalValues").GetComponent<JournalValues>();
		foreach (var key in PersistenceController.instance.journalState.journalEntries)
		{
			putJournalEntry(key.Key, key.Value);
		}

	}

	/// <summary>
	/// Adds a new journal slot to the journal interface, populated with the desired text.
	/// </summary>
	/// <param name="txt">Text to be added to the journal slot entry.</param>
	public void putJournalEntry(string txt, int score)
	{

		if (!PersistenceController.instance.journalState.journalEntries.ContainsKey (txt)) {
			//if(PersistenceController.JournalState.journal)
			GameObject slot = GameObject.Instantiate (JournalSlot);
			//slot.AddComponent<RectTransform>();
			slot.AddComponent<Button> ();
			slot.AddComponent<Text> ();
			Button b = slot.GetComponentInChildren<Button> ();
			b.onClick.AddListener (TaskOnClick);
			_entries.Add (b);
			Text text = slot.GetComponent<Text> ();
			journalEntry = slot.GetComponentInChildren<Text> ();
			slot.transform.SetParent (this.gameObject.transform, false);
			journalEntry.text = txt;
			

			Journal jrnl = slot.GetComponent<Journal> (); //Get the journal object of the slot instance.
			
			_score = score; //Set the journal entry value. Hardcoded as 6 as an example.
			PersistenceController.instance.journalState.journalEntries.Add (txt, score);
			journalTabImage.sprite = Resources.Load<Sprite> ("Icons/JournalIconAlert");
		} else {
			//if(PersistenceController.JournalState.journal)
			GameObject slot = GameObject.Instantiate (JournalSlot);
			//slot.AddComponent<RectTransform>();
			slot.AddComponent<Button>();
			slot.AddComponent<Text>();
			Button b = slot.GetComponentInChildren<Button> ();
			b.onClick.AddListener (TaskOnClick);
			_entries.Add (b);
			Text text = slot.GetComponent<Text> ();
			journalEntry = slot.GetComponentInChildren<Text> ();
			slot.transform.SetParent (this.gameObject.transform, false);
			journalEntry.text = txt;
			Journal jrnl = slot.GetComponent<Journal> (); //Get the journal object of the slot instance.

			_score = score; //Set the journal entry value. Hardcoded as 6 as an example.
			journalTabImage.sprite = Resources.Load<Sprite> ("Icons/JournalIconAlert");
		}
		//journalEntry.text = PersistenceController.JournalState.journal;
	}

	void TaskOnClick()
	{
		GameObject selectedSlot = EventSystem.current.currentSelectedGameObject;
		Journal jrnl = selectedSlot.GetComponent<Journal> ();
		//Debug.Log(jrnl.GetComponentInChildren<Text>().text);

		//Text text = selectedSlot.GetComponent<Text>();
		Text text = selectedSlot.GetComponentInChildren<Text>();
		TrialScript.selectedText = text.text;
		foreach (var key in PersistenceController.instance.journalState.journalEntries)
		{
			string k = key.Key;
			if (k.Equals(text.text))
			{
				jrnl.journalEntryValue = key.Value;
			}
		}
		Button b = selectedSlot.GetComponentInChildren<Button>();
		b.interactable = false;

	}

	/// <summary>
	/// Returns the currently selected item by the player.
	/// </summary>
	/// <returns></returns>
	public int GetSelectedEntry()
	{
		return journalEntryValue;
	}


}

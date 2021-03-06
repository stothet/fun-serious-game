﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif


/// <summary>
/// Author Andon
/// HThis class holds the inventory of the player
/// </summary>
public class Inventory : MonoBehaviour {
    public List<GameObject> _slots = new List<GameObject>();
    public List<Item> _items = new List<Item>();
	public GameObject panel;
    public GameObject slots;
	public Image _inventoryTabImage;

    ItemDatabase database;
    Journal _journal;
    int x = -90; //Initial x coordinate of the first slot.
    int y = 100; //Initial y coordinate of the first slot.
	private Item _selectedItem;

    // Use this for initialization
    void Start() {
        int _slotAmount = 0; // Variable used to notify the slotscript whether to enable the sprite icon in the slot interface.
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>(); //Instantiate the database
        _journal = GameObject.FindGameObjectWithTag("Journal").GetComponent<Journal>();
		_inventoryTabImage = GameObject.FindGameObjectWithTag("InventoryTab").GetComponent<Image>();

        for (int i = 1; i < 6; i++) // Create 5 columns of slots
        {
            for (int j = 1; j < 6; j++) // Create 5 rows of slots.
            {
                GameObject slot = Instantiate(slots); // Instantiate a slot
                slot.GetComponent<SlotScript>()._slotNumber = _slotAmount; // Set the slot number of the current slot as a field value.
                slot.transform.SetParent(this.gameObject.transform, false); // Parent/Slot needs to be a GameObject
                _slots.Add(slot); //
                _items.Add(new Item());
                slot.name = "SlotNumber " + i + "." + j; // Set the name of the slot in row, column notation for convenience.
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0); // Set the coordinates of the slot in the inventory interface.
                x = x + 45; // Set x coordinate of the next slot.
                if (j == 5) // Set x and y coordinates of the next slot if at the end of the row.
                {
                    x = -90;
                    y = y - 50;
                }
                _slotAmount++;
            }
        }
        for(int i = 0; i<PersistenceController.instance.inventoryState.database.Count; i++)
        {
            addItem(PersistenceController.instance.inventoryState.database[i]);
        }
        // Add items you want to show up in the inventory here. The number is the unique ID of the item.
        //addItem(Configuration.billArtHistoryReportName);
        //addItem(1);
		panel.SetActive(false);
	}

    /// <summary> Utility method to add the desired item into the inventory </summary>
    public void addItem(string name)
    {
        Item item = database.items[name];
        if (item != null)
        {
            if (!PersistenceController.instance.inventoryState.database.Contains(name)) {
                PersistenceController.instance.inventoryState.database.Add(name);
            }
            addToEmptySlot(item);
			_inventoryTabImage.sprite = Resources.Load<Sprite>("Icons/BagIconAlert");
        
        }
        else
        {
            throw new System.Exception("Expected item to be in database");
        }
       
    }

    // Helper method to checks whether the slot is free. If a slot is a free, then add the desired item, else go to the next available slot.
    void addToEmptySlot(Item item)
    {
        for (int i = 0; i < 25; i ++)
        {
            if (_items[i]._itemName == null)
            {
                _items[i] = item;
                if (_slots[i] != null)
                {
                    _slots[i].name = _items[i]._itemName;
                }
              
                break;
            }
        }
    }

	/// <summary>
	/// Used by SlotScript to set the currently selected item.
	/// </summary>
	/// <param name="item"></param>
	public void SetSelectedItem(Item item)
	{
		_selectedItem = item;
	}

	/// <summary>
	/// Returns the currently selected item by the player.
	/// </summary>
	/// <returns></returns>
	public Item GetSelectedItem()
	{
		return _selectedItem;
	}
}

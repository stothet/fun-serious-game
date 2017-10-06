using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author Andon
/// This class stores all possible items that our game would ever need in a public List
/// of items. Every item in the list has a name, itemID, item description, item quantity (if needed),
/// and the name of the sprite in the Resources folder.
/// </summary>
public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();
    //Add additional items to the database with the following rubber duck template.
	void Start () {
        //Item constructor is Item(String itemName, int itemId, string description, int itemQuantity, Enum evidenceType, string spriteName)
        items.Add(new Item("Rubber Duck", 0, "Just a rubber duck.", 1, Item.ItemType.DUMMY, "duck_yellow"));
        items.Add(new Item("Evidence Duck", 1, "This looks useful.", 1, Item.ItemType.DUMMY, "duck_yellow"));
    }

}

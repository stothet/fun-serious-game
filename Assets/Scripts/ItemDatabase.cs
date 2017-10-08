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
        items.Add(new Item("Bruce's register entry", 0, "Register entry for Bruce, with his signature and an official timestamp.", 1, Item.ItemType.EVIDENCE, "book"));
        items.Add(new Item("Scrunched up paper", 1, "Bill's Art History report, scrunched to a ball.", 1, Item.ItemType.DUMMY, "paper"));
        items.Add(new Item("Detention note", 2, "Detention note for Bruce, with the date and time nowhere to be seen.", 1, Item.ItemType.DUMMY, "slip"));
    }

    /// <summary>
    /// Returns the associated item id with the item name within database.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int NameToID(string name)
    {
        if (name.Equals("Bruce's register entry"))
        {
            return 0;
        } else if (name.Equals("Scrunched up paper"))
        {
            return 1;
        } else if (name.Equals("Detention note"))
        {
            return 2;
        }

        return -1;
    }

}

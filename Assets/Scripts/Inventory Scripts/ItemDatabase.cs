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

    //Add additional items to the database with the following rubber duck template.
    void Start () {
        //Item constructor is Item(String itemName, string description, int itemValue, Enum evidenceType, string spriteName)
        // Dictionary 
        PersistenceController.InventoryState.database[Configuration.bruceRegisterEntryName] = new Item(Configuration.bruceRegisterEntryName, Configuration.bruceRegisterEntryDescription, 5, Item.ItemType.EVIDENCE, "book");
        PersistenceController.InventoryState.database[Configuration.billArtHistoryReportName] = new Item(Configuration.billArtHistoryReportName, Configuration.billArtHistoryReportDescription, -5, Item.ItemType.DUMMY, "paper");
        PersistenceController.InventoryState.database[Configuration.detentionNoteName] = new Item(Configuration.detentionNoteName, Configuration.detentionNoteDescription, -5, Item.ItemType.DUMMY, "slip");
    }

}

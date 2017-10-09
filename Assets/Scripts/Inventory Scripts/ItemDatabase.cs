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
        //Item constructor is Item(String itemName, string description, int itemQuantity, Enum evidenceType, string spriteName)

        // Dictionary 
        PersistenceController.InventoryState.database[Configuration.bruceRegisterEntryName] = new Item(Configuration.bruceRegisterEntryName, Configuration.bruceRegisterEntryDescription, 1, Item.ItemType.EVIDENCE, "book");
        PersistenceController.InventoryState.database[Configuration.BillArtHistoryReportName] = new Item(Configuration.BillArtHistoryReportName, Configuration.BillArtHistoryReportDescription, 1, Item.ItemType.DUMMY, "paper");
        PersistenceController.InventoryState.database[Configuration.DetentionNoteName] = new Item(Configuration.DetentionNoteName, Configuration.DetentionNoteDescription, 1, Item.ItemType.DUMMY, "slip");
    }

}

using UnityEngine;
using System.Collections;


/// <summary>
/// Author Andon
/// This class represents an instance of an 'Item' object. Item has two constructors:
/// The empty constructor instantiates a 'null' item so that every slot has an item.
/// When a real item is added by the user, the second constructor is called to replace the
/// null item object occupying the inventory slot.
/// </summary>
public class Item {

    public string _itemName; //Name of the item.
    public int _itemId; //Unique ID of the item.
    public string _itemDescription; //Description of the item.
    public int _itemValue; //int amount of items to indicate amount of stackable items. Possibly useful
    public ItemType _itemType; //Enum that identifies whether the object is related to evidence, or whether it is a dummy item. (ItemType.EVIDENCE and ItemType.DUMMY respectively).
    public Sprite _itemIcon; //The image used to represent the item.

    //Enum to identify object type.
    public enum ItemType {
        EVIDENCE,
        DUMMY
    }

    //Empty constructor to fill a slot with a nulled item.
    public Item() { }

    //Constructor called when an actual item wants to be added to the inventory slot.
    public Item(string name, int id, string desc, int value, ItemType type, string spriteName)
    {
        _itemName = name;
        _itemId = id;
        _itemDescription = desc;
        _itemValue = value;
        _itemType = type;
        _itemIcon = Resources.Load<Sprite>("" + spriteName);
    }
}

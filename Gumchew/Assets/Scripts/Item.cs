using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string _itemName;
    public int _itemId;
    public string _itemDescription;
    public int _itemValue; //int amount of items to indicate amount of stackable items. Possibly useful
    public ItemType _itemType;
    public Sprite _itemIcon;
    public GameObject _itemModel;


    public enum ItemType {
        EVIDENCE,
        DUMMY
    }

    public Item(string name, int id, string desc, int value, ItemType type)
    {
        _itemName = name;
        _itemId = id;
        _itemDescription = desc;
        _itemValue = value;
        _itemType = type;
        //_itemIcon = Resources.Load<SPrite>("" + name);
    }
}

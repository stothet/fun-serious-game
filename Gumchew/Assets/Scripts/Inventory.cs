using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public List<GameObject> _slots = new List<GameObject>();
    public List<Item> _items = new List<Item>();
    public GameObject slots;
    ItemDatabase database;
    int x = -110;
    int y = 110;
	// Use this for initialization
	void Start () {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                GameObject slot = Instantiate(slots);
                slot.transform.SetParent(this.gameObject.transform, false);
                _slots.Add(slot);
                _items.Add(new Item());
                //this.gameObject.transform.SetParent(slot.transform.parent);
                //slot.transform.parent = this.gameObject.transform;
                slot.name = "SlotNumber row.col " + i + "." + j;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 55;
                if (j == 5)
                {
                    x = -110;
                    y = y - 55;
                }
            }
        }
        addItem(0);
        Debug.Log(_items[0]._itemName);
	}

    void addItem(int id)
    {
        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i]._itemId == id)
            {
                Item item = database.items[i];
                addToEmptySlot(item);
                break;
            }
        }
    }

    void addToEmptySlot(Item item)
    {
        for (int i = 0; i < 24; i ++)
        {
            if (_items[i]._itemName == null)
            {
                _items[i] = item;
                break;
            }
        }
    }
}

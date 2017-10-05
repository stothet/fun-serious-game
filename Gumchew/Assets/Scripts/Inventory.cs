using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public List<GameObject> _slots = new List<GameObject>();
    public List<Item> _items = new List<Item>();
    public GameObject slots;
    int x = -110;
    int y = 110;
	// Use this for initialization
	void Start () {
	    for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                GameObject slot = Instantiate(slots);
                slot.transform.SetParent(this.gameObject.transform, false);
                _slots.Add(slot);
                //this.gameObject.transform.SetParent(slot.transform.parent);
                //slot.transform.parent = this.gameObject.transform;
                slot.name = "Inventory " + i + "." + j;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 55;
                if (j == 5)
                {
                    x = -110;
                    y = y - 55;
                }
            }
        }
	}

}

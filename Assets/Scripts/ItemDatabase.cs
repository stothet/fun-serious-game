using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();
	// Use this for initialization
	void Start () {

        items.Add(new Item("Wet sock", 0, "Just a wet sock.", 1, Item.ItemType.DUMMY));

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Author Andon
/// This class handles the utility for enabling sprites and updating the description pane.
/// </summary>
public class SlotScript : MonoBehaviour, IPointerDownHandler {

    public Item _item;
    Image _itemImage;
    public int _slotNumber;
    Inventory _inventory;
    Journal _journal;
    UpdateText _itemNameInPanel;
    UpdateText _itemDescriptionInPanel;
	// Use this for initialization
	void Start () {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        _itemNameInPanel = GameObject.FindGameObjectWithTag("NameOfItem").GetComponent<UpdateText>();
        _itemDescriptionInPanel = GameObject.FindGameObjectWithTag("DescriptionOfItem").GetComponent<UpdateText>();
        _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
    //The update method checks if there exists an actual item in the slot. If there is, then we enable the sprite icon to be displayed.
	void Update () {
	    if (Inventory._items[_slotNumber]._itemName != null)
        {
            _item = Inventory._items[_slotNumber];
            _itemImage.enabled = true;
            _itemImage.rectTransform.sizeDelta = new Vector2(30, 30);
            _itemImage.sprite = Inventory._items[_slotNumber]._itemIcon;

        }
        else
        {
            _itemImage.enabled = false;

        }
	}


    //If there exists an item in a slot and it is clicked, update the information panel to display the name of the item, and the description.
    //Currently bugged, will show an error message in the console displaying NullReferenceException when clicking a slot with no item in it.
    public void OnPointerDown(PointerEventData data)
    {
        if (_item._itemName != null)
        {
            _itemNameInPanel.SetNewText(_item._itemName);
            _itemDescriptionInPanel.SetNewText(_item._itemDescription);
        }

    }
}

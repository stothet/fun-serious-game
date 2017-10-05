using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour, IPointerDownHandler {

    public Item _item;
    Image _itemImage;
    public int _slotNumber;
    Inventory _inventory;
	// Use this for initialization
	void Start () {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_inventory._items[_slotNumber]._itemName != null)
        {
            _item = _inventory._items[_slotNumber];
            _itemImage.enabled = true;
            _itemImage.sprite = _inventory._items[_slotNumber]._itemIcon;
        }
        else
        {
            _itemImage.enabled = false;

        }
	}

    void SayName()
    {
        Debug.Log(transform.name);
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Click");
    }
}

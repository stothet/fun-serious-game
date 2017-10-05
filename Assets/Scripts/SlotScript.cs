using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour, IPointerDownHandler {

    public Item _item;
    Image _itemImage;
	// Use this for initialization
	void Start () {
        _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_item != null)
        {
            _itemImage.enabled = true;
            _itemImage.sprite = _item._itemIcon;
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

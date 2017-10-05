using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class Slot : MonoBehaviour, IDropHandler {
    public GameObject item {
        get {
            if (transform.childCount > 0) {
                return transform.GetChild(0).gameObject;
            } return null;
        }
    }
    #region IdropHandler implementation 
    public void OnDrop(PointerEventData eventData) {
        if (!item) { // check if there is already an item
            DragHandler.item.transform.SetParent(transform); // grab item that is dropped
        }
    }
    #endregion
}﻿
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// Allows an object to be dragged by clicking and holding down the left mouse button.
/// </summary>
/// <remarks>
/// The object's position and parent is reset to it's original position if it is not dragged to a valid panel 
/// </remarks>
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject item;  // item being dragged
    Transform startParent;          // inital parent of the object
    Vector3 startPosition;          // initial posiiton of the object

    /// <summary>
    /// Initialise the item being dragged, the start position and parent of the object 
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// Set the position of the object being dragged to the mouse position
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Change the position of the object depending on where the object is released
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        // if the parent of the object has not changed, then return the object to it's initial position
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
}
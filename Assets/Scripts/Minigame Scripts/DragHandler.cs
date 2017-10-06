using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject item;  // the item being dragged 
    Transform startParent;
    Vector3 startPosition;
    bool start = true;
    //Sprite sprite; 

    public void OnBeginDrag(PointerEventData eventData) {
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        item.GetComponent<LayoutElement>().ignoreLayout = true;
        item.transform.SetParent(item.transform.parent.parent);
    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData) {
        item = null;
        if (transform.parent == startParent) {
            transform.position = startPosition;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        item.GetComponent<LayoutElement>().ignoreLayout = false;
    }
}
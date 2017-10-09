using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Allows an object to be placed as a child of this object with the appropriate position.
/// </summary>
/// <remarks>
/// Invalid object are not set as children
/// </remarks>
public class Drop : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// The item being dragged
    /// </summary>
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    /// <summary>
    /// Place the object in the slot if it is a valid item and valid slot
    /// </summary>
    #region IdropHandler implementation 
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)// if not item in the slot, put object into this slot
        {
            Drag.item.transform.SetParent(transform);
        }
        else // if there is already an item in the slot, switch the positions of the items
        {
            Transform aux = Drag.item.transform.parent;
            Drag.item.transform.SetParent(transform);
            item.transform.SetParent(aux);
        }
    }
    #endregion
}
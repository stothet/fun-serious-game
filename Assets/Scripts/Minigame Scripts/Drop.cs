using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class Drop : MonoBehaviour, IDropHandler
{
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
    #region IdropHandler implementation 
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            Drag.item.transform.SetParent(transform);
        }
        else
        {
            Transform aux = Drag.item.transform.parent;
            Drag.item.transform.SetParent(transform);
            item.transform.SetParent(aux);
        }
    }
    #endregion
}
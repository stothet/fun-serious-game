using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryClickScript : MonoBehaviour
{

    //public Button yourButton;
    public GameObject inventoryPanel;
    private bool active = false;
    private string currentTab; // should be null at the start, but currently inventory displays on beginning

    // Use this for initialization, register all child buttons of the inventory panel with a listener
    void Start()
    {
		inventoryPanel.SetActive (false);
        Button[] btn = GetComponentsInChildren<Button>();
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].onClick.AddListener(TaskOnClick);
        }
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        var go = EventSystem.current.currentSelectedGameObject; // get the event that triggered this function
        if (!active) // the inventory panel is not active
        {
            currentTab = go.name; // set the currentTab name to the event name
            inventoryPanel.SetActive(true); // show the panel
            active = true; // bool to store the state of the panel
        }
        else
        {
            if (go != null)
                if (currentTab != null && currentTab.Equals(go.name))
                {
                    active = false;
                    inventoryPanel.SetActive(false);
                }
                else
                {
                    currentTab = go.name;
                    Debug.Log("Clicked on : " + go.name);
                }

            else
                Debug.Log("currentSelectedGameObject is null");
        }

        /* Debug.Log("Hello!");
         active = !active;
         inventoryPanel.SetActive(active);*/
    }
}

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
            if (go != null) // if the event triggering this, is not null
                if (currentTab != null && currentTab.Equals(go.name)) // checking if currentTab is set, also checks that the currentTab is the event that triggered the click
                {
                    active = false;
                    inventoryPanel.SetActive(false); // current active tab is the same as the event, so we toggle the view
                }
                else
                {
                    currentTab = go.name; // current tab is not set yet, we set it to the event that triggered the click
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

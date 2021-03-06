﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryClickScript : MonoBehaviour
{

    //public Button yourButton;
    public GameObject inventoryPanel;
    public GameObject journalPanel;
    public GameObject SOMET;
    public Button Submit;
    public TrialScript trial;
    Image inventoryTabImage;
  	Image journalTabImage;

    private bool active = false;
    private string currentTab; // should be null at the start, but currently inventory displays on beginning

    // Use this for initialization, register all child buttons of the inventory panel with a listener
    void Start()

    {
        trial = FindObjectOfType<TrialScript>();
        inventoryTabImage = GameObject.FindGameObjectWithTag("InventoryTab").GetComponent<Image>();
    		journalTabImage = GameObject.FindGameObjectWithTag("JournalTab").GetComponent<Image>();
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
            SOMET.SetActive(true);
			//inventoryTabImage.sprite = Resources.Load<Sprite>("Icons/BagIcon");
            getTabEvent(currentTab).SetActive(true);
            Debug.Log("did this call?");
            //inventoryPanel.SetActive(true); // show the panel
            active = true; // bool to store the state of the panel
        }
        else
        {
            if (go != null) // if the event triggering this, is not null
                if (currentTab != null && currentTab.Equals(go.name)) // checking if currentTab is set, also checks that the currentTab is the event that triggered the click
                {
                    active = false;
                    SOMET.SetActive(false);
                    getTabEvent(currentTab).SetActive(false); // current active tab is the same as the event, so we toggle the view
                    Submit.gameObject.SetActive(false);
                }
                else
                {
                    currentTab = go.name; // current tab is not set yet, we set it to the event that triggered the click
                    getTabEvent(currentTab).SetActive(true);
                    Debug.Log("Clicked on : " + go.name);
                }

            else
                Debug.Log("currentSelectedGameObject is null");
        }

        /* Debug.Log("Hello!");
         active = !active;
         inventoryPanel.SetActive(active);*/
    }

    private GameObject getTabEvent(string name)
    {
        if (trial.trialActive)
        {
            Submit.gameObject.SetActive(true);
        }

        if(name == "InventoryTab")
        {
            Debug.Log("Hello");
			inventoryTabImage.sprite = Resources.Load<Sprite>("Icons/BagIcon");
            journalPanel.SetActive(false);
            return inventoryPanel;
        } else
        {
            Debug.Log("DOES THIS ONE WORK!?!?!?!?");
			journalTabImage.sprite = Resources.Load<Sprite>("Icons/JournalIcon");
            inventoryPanel.SetActive(false);
            return journalPanel;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{

    public EventSystem eventSystem;
    public GameObject gameObject;

    private bool selected;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && selected == false)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            selected = true;
        }
    }

    private void OnDisable()
    {
        selected = false;
    }
}
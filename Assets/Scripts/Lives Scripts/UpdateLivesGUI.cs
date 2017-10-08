using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateLivesGUI : MonoBehaviour {

    Image life1;
    Image life2;
    Image life3;

    // Use this for initialization
    void Start()
    {
        life1 = GameObject.Find("LifeImage1").GetComponent<Image>();
        life2 = GameObject.Find("LifeImage2").GetComponent<Image>();
        life3 = GameObject.Find("LifeImage3").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        int numLives = PlayerController.getNumberOfLives();
        life1.enabled = true;
        life2.enabled = true;
        life3.enabled = true;

        if (numLives < 3)
        {
            life3.enabled = false;
        }
        if (numLives < 2)
        {
            life2.enabled = false;
        }
        if (numLives < 1) // Shouldn't be needed because game over, but just in case.
        {
            life1.enabled = false;
        }
    }
}

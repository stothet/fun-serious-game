using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This class controls the player's life system 
/// </summary>
public class UpdateLivesGUI : MonoBehaviour {

    Image life1;
    Image life2;
    Image life3;

    // Initialise lives sprites
    void Start()
    {
        life1 = GameObject.Find("LifeImage1").GetComponent<Image>();
        life2 = GameObject.Find("LifeImage2").GetComponent<Image>();
        life3 = GameObject.Find("LifeImage3").GetComponent<Image>();
    }

    // Update the player's current lives
    void Update () {
        int numLives = PersistenceController.PlayerState.lives;
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

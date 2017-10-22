using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This class controls the player's life system 
/// </summary>
public class UpdateLivesGUI : MonoBehaviour {

    // Public for testability
    public Image life1;
    public Image life2;
    public Image life3;

   public UpdateLivesGUI()
    {

    }

    // Initialise lives sprites
    void Start()
    {
        life1 = GameObject.Find("LifeImage1").GetComponent<Image>();
        life2 = GameObject.Find("LifeImage2").GetComponent<Image>();
        life3 = GameObject.Find("LifeImage3").GetComponent<Image>();
    }

    // Update the player's current lives
    void Update () {
        int numLives = PersistenceController.instance.playerState.lives;
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

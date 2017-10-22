using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlowMinigameInitialiser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SCENE SWITCCCCH GUUURL");
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);
        }
    }
}

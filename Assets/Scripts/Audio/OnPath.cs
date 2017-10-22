using UnityEngine;
using System.Collections;

public class OnPath : MonoBehaviour {
    private PlayerAudio footsteps;

	// Use this for initialization
	void Start () {
        footsteps = GameObject.Find("Player").GetComponent<PlayerAudio>();
        footsteps.onPath = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("On Path");
            footsteps.onPath = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Off Path");
            footsteps.onPath = false;
        }
    }
}

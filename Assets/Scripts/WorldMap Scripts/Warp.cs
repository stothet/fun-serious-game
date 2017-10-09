using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTarget; // positional information of the warp target

    void OnTriggerEnter2D(Collider2D other) // when a collision is a trigger
    {
        Debug.Log("An object collidied.");
        other.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

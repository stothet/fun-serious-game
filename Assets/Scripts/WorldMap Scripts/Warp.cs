using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTarget; // positional information of the warp target

    void OnTriggerEnter2D(Collider2D other) // when a collision is a trigger
    {
        //Debug.Log("An object collidied.");
        other.gameObject.transform.position = warpTarget.position; // player collides with this, we warp the player to the warp target position specified
        Camera.main.transform.position = warpTarget.position; // mvoe camera with the warp
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

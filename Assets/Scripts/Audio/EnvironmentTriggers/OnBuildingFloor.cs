using UnityEngine;
using System.Collections;

public class OnBuildingFloor : MonoBehaviour
{
    private PlayerAudio footsteps;

    // Use this for initialization
    void Start()
    {
        footsteps = GameObject.Find("Player").GetComponent<PlayerAudio>();
        footsteps.onBuildingFloor = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            footsteps.onBuildingFloor = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            footsteps.onBuildingFloor = false;
        }
    }
}

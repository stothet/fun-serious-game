using UnityEngine;
using System.Collections;

public class OnGrass: MonoBehaviour
{
    private PlayerAudio footsteps;

    // Use this for initialization
    void Start()
    {
        footsteps = GameObject.Find("Player").GetComponent<PlayerAudio>();
        footsteps.onGrass = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            footsteps.onGrass = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            footsteps.onGrass = false;
        }
    }
}

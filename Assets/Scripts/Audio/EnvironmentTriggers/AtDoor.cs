using UnityEngine;
using System.Collections;

public class AtDoor : MonoBehaviour {

    private PlayerAudio player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerAudio>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.PlayDoorSound();
        }
    }

}

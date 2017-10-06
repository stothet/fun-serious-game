using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;
	private Vector3 offset;
    Camera mycam;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
        mycam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void LateUpdate () {
        mycam.orthographicSize = (Screen.height / 100f) / 4f;

        if (player)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, 100f) + new Vector3(0, 0, - 10);
        }
	}
}

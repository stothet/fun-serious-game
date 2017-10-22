using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;
	private Vector3 offset;
    Camera mycam;
    public float speed;
    public float shakeSpeedY;
    public float shakeSpeedX;
    public bool tiltActive = false;
	private Vector3 currentGyroPlacement;

    // Use this for initialization
    void Start () {
		offset = transform.position - player.transform.position;
        mycam = GetComponent<Camera>();
        Input.gyro.enabled = true;
        tiltActive = false;
	}

	// Update is called once per frame
	void LateUpdate () {
        if (tiltActive) {
			currentGyroPlacement += Input.gyro.rotationRateUnbiased;
			/*if (currentGyroPlacement.y > shakeSpeedY || currentGyroPlacement.y < shakeSpeedY * -1)
			{
				transform.Translate(new Vector3(0, currentGyroPlacement.y, 0)*Time.deltaTime);
			}
			if (currentGyroPlacement.x > shakeSpeedX || currentGyroPlacement.x < shakeSpeedX * -1)
			{
				transform.Translate(new Vector3(currentGyroPlacement.y, 0, 0) * Time.deltaTime);
			}*/
			transform.Translate (new Vector3(currentGyroPlacement.y, currentGyroPlacement.x*-1, 0)*Time.deltaTime);
        } else {
            if (player && !tiltActive)
            {
                transform.position = Vector3.Lerp(transform.position, player.position, 100f) + new Vector3(0, 0, -10);
            }
        }
	}

    void toggleTiltMode()
    {
        Debug.Log("Is this called?");
        tiltActive = !tiltActive;
		currentGyroPlacement = new Vector3 (0, 0, 0);
    }
}

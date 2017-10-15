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

    // Use this for initialization
    void Start () {
		offset = transform.position - player.transform.position;
        mycam = GetComponent<Camera>();
        Input.gyro.enabled = true;
        tiltActive = false;
	}

	// Update is called once per frame
	void LateUpdate () {
        mycam.orthographicSize = (Screen.height / 100f) / 4f;

        Vector3 gyroMovement = Input.gyro.rotationRateUnbiased;
        float previousMovement = gyroMovement.x; // switch axises since y and x are flipped on phone
        gyroMovement.x = gyroMovement.y;
        gyroMovement.y = previousMovement;
        if (tiltActive) {
            if (gyroMovement.y > shakeSpeedY || gyroMovement.y < shakeSpeedY * -1)
            {
                transform.Translate(new Vector3(0, gyroMovement.y, 0) * Time.deltaTime * speed);
            }
            if (gyroMovement.x > shakeSpeedX || gyroMovement.x < shakeSpeedX * -1)
            {
                transform.Translate(new Vector3(gyroMovement.x, 0, 0) * Time.deltaTime * speed);
            }
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
    }
}

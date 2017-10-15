using UnityEngine;
using System.Collections;

public class GyroController : MonoBehaviour {

    Camera mycam;

    float speed = 6;
    public float shakeSpeedY;
    public float shakeSpeedX;

	// Use this for initialization
	void Start () {
        mycam = GetComponent<Camera>();
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("???????");
        Vector3 gyroMovement = Input.gyro.rotationRateUnbiased;
        float previousMovement = gyroMovement.x; // switch axises since y and x are flipped on phone
        gyroMovement.x = gyroMovement.y;
        gyroMovement.y = previousMovement;
        if (gyroMovement.y > shakeSpeedY || gyroMovement.y < shakeSpeedY * -1)
        {
            transform.Translate(new Vector3(0, gyroMovement.y, 0)*Time.deltaTime*speed);
        }
        if (gyroMovement.x > shakeSpeedX || gyroMovement.x < shakeSpeedX * -1)
        {
            transform.Translate(new Vector3(gyroMovement.x, 0, 0) * Time.deltaTime * speed);
        }
        /*Vector3 dir  = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir *= Time.deltaTime;*/

    }
}

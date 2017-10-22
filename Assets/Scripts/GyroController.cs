using UnityEngine;
using System.Collections;

public class GyroController : MonoBehaviour {

    Camera mycam;

    float speed = 6;
    public float shakeSpeedY;
    public float shakeSpeedX;
	public Vector3 currentGyroPlacement;

	// Use this for initialization
	void Start () {
        mycam = GetComponent<Camera>();
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("???????");
		currentGyroPlacement += Input.gyro.rotationRateUnbiased;
		/*if (currentGyroPlacement.y > shakeSpeedY || currentGyroPlacement.y < shakeSpeedY * -1)
        {
			transform.Translate(new Vector3(0, currentGyroPlacement.y, 0)*Time.deltaTime);
        }
		if (currentGyroPlacement.x > shakeSpeedX || currentGyroPlacement.x < shakeSpeedX * -1)
        {
			transform.Translate(new Vector3(currentGyroPlacement.x, 0, 0) * Time.deltaTime);
        }*/
		transform.Translate (currentGyroPlacement);
        /*Vector3 dir  = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir *= Time.deltaTime;*/

    }
}

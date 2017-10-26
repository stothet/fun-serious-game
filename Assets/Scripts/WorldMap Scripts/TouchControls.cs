using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {
	public static int directionX = 0;
	public static int directionY = 0;
	// Use this for initialization
	void Start () {
		directionX = 0;
		directionY = 0;
	}
	public void leftButtonDown() {
		directionX = -1;
	}	
	public void rightButtonDown() {
		directionX = 1;
	}	
	public void upButtonDown() {
		directionY = 1;
	}	
	public void downButtonDown() {
		directionY = -1;
	}	
	public void buttonUp() {
		directionX = 0;
		directionY = 0;
	}	
}

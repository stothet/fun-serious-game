﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the camera for the main menu
/// </summary>
public class MainMenuCameraController : MonoBehaviour {

	public float x;
	public float y;
	public Camera camera;

	// Use this for initialization
	void Start () {
		Rect rect = new Rect ();
		rect.x = x;
		rect.y = y;
		camera.pixelRect = rect;
	}
		
}

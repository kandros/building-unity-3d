﻿using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public float sensitivityHor = 9.0f;
	public float sensitivityvert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	public float _rotationX = 0;

	public RotationAxes axes = RotationAxes.MouseXandY;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			// horizontal rotation
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			// vertical rotation
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityHor;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
		else {
			//both rotation
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityvert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}

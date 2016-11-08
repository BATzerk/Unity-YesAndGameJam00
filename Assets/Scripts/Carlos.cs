using UnityEngine;
using System.Collections;

public class Carlos : MonoBehaviour {
	// Constants
//	private const float movementSpeed = 220.2f;
	// Components
	private Rigidbody myRigidbody;
	// Properties
	[SerializeField] private float fVelSensitivity = 0.012f;
	[SerializeField] private float fVelFriction = 0.998f;
	[SerializeField] private float rotationYVelSensitivity = 0.8f;
	[SerializeField] private float rotationYVelFriction = 0.96f;
//	private Vector2 velHorz;
	private float fVel;
	private float rotationYVel;



	// ----------------------------------------------------------------
	//  Awake
	// ----------------------------------------------------------------
	private void Awake () {
		myRigidbody = GetComponent<Rigidbody> ();
	}



	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		// Update velHorz!
//		velHorz = InputController.JoystickLAxis;
//		// Apply friction!
//		velHorz *= 0.9f;
		// Apply velHorz!
		/*
		// Get direction the controller is pushing!
		Vector3 directionVector = new Vector3 (InputController.PlayerAxisInput.x, InputController.PlayerAxisInput.y, 0);
		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			float directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;

			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min (1, directionLength);

			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;

			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}

		// Rotate the input vector into camera space so up is camera's up and right is camera's right
		directionVector = Camera.main.transform.rotation * directionVector;

		// Rotate input vector to be perpendicular to character's up vector
		Quaternion camToCharacterSpace = Quaternion.FromToRotation (-Camera.main.transform.forward, transform.up);
		directionVector = (camToCharacterSpace * directionVector);
		*/

		Vector3 directionVector = new Vector3 (InputController.PlayerAxisInput.x, 0, InputController.PlayerAxisInput.y);

		// Use directionVector!
		fVel += directionVector.z * fVelSensitivity;
		fVel *= fVelFriction;
		rotationYVel += directionVector.x * rotationYVelSensitivity;
		rotationYVel *= rotationYVelFriction;

		// Apply fVel and rotationYVel!
		float angleY = transform.localEulerAngles.y * Mathf.Deg2Rad;
		this.transform.localPosition += new Vector3 (Mathf.Sin (angleY), 0, Mathf.Cos (angleY)) * fVel;
		this.transform.localEulerAngles += new Vector3 (0, rotationYVel, 0) * Mathf.Clamp (fVel, -0.1f, 0.1f)*2f;

//		// Apply force!
//		Vector3 horzForce = directionVector * 50f;
//		myRigidbody.AddForce (horzForce);
	}


}



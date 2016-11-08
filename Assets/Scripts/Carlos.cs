using UnityEngine;
using System.Collections;

public class Carlos : MonoBehaviour {
	// Constants
//	private const float movementSpeed = 220.2f;
	// Components
	private Rigidbody myRigidbody;
	// Properties
	private Vector2 velHorz;



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

		// Apply force!
		Vector2 horzForce = InputController.JoystickLAxis * 50f;
		myRigidbody.AddForce (new Vector3 (horzForce.x, 0, horzForce.y));
	}


}



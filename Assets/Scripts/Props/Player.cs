using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Prop {
	// Constants
	private const float friction = 0.72f; // applied to vel.
	private const float GRAVITY = -0.18f;
	private const float MOVEMENT_SENSITIVITY_AIR = 0.05f;
	private const float MOVEMENT_SENSITIVITY_GROUND = 0.08f;
	// Components
	[SerializeField] private BoxCollider interactionTrigger;
	[SerializeField] private CharacterController characterController;
	[SerializeField] private GameObject bodyMeshGO;
	// Properties
	private float movementSensitivity; // higher means we move faster.
	private Vector3 vel; // NOTE: This is ONLY horizontal velocity! We do not store vertical velocity.
	// References
	[SerializeField] private GameController gameControllerRef;
	[SerializeField] private EffectsController effectsControllerRef;


	// Getters
	private Collider[] GetCollidersTouchingMe () { return Physics.OverlapBox (Pos+interactionTrigger.transform.localPosition+interactionTrigger.center, interactionTrigger.size*0.5f); }
	private T GetClosestPropTouching<T> () where T : Prop {
		int closestIndex = -1;
		float closestDistance = float.PositiveInfinity;
		Collider[] cols = GetCollidersTouchingMe ();
		for (int i=0; i<cols.Length; i++) {
			Prop thisSeedHole = GetPropFromCollider<T> (cols [i]);
			if (thisSeedHole != null) {
				float thisDistance = Vector3.Distance (Pos, thisSeedHole.transform.localPosition);
				if (thisDistance < closestDistance) {
					closestIndex = i;
					closestDistance = thisDistance;
				}
			}
		}
		// Return our findingz.
		if (closestIndex >= 0) { return GetPropFromCollider<T> (cols[closestIndex]); }
		else { return null; }
	}

	private Vector3 ConstantSlerp (Vector3 from, Vector3 to, float angle) {
		float value = Mathf.Min (1, angle / Vector3.Angle(from, to));
		return Vector3.Slerp (from, to, value);
	}
	private Vector3 ProjectOntoPlane (Vector3 v, Vector3 normal) {
		return v - Vector3.Project(v, normal);
	}



	// ----------------------------------------------------------------
	//  Awake
	// ----------------------------------------------------------------
	override protected void Awake () {
		base.Awake ();

		// Reset pos, vel, etc.!
		vel = Vector3.zero;
	}




	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------




	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
//	public void OnTouchSeed (Seed seed) {
//		PickUpSeed (seed);
//	}



	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		// Movement
		UpdateVel ();
		ApplyFriction ();
		ApplyVel ();

		UpdateWaddle ();

//		// Button input
//		RegisterButtons ();
	}

	private void UpdateVel () {
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

		// Grounded!
		if (characterController.isGrounded) {
			movementSensitivity = MOVEMENT_SENSITIVITY_GROUND;
//			vel = new Vector3 (vel.x, 0, vel.z); // no y vel on the ground, boss.
		}
		else {
			movementSensitivity = MOVEMENT_SENSITIVITY_AIR;
			// Apply gravity!
//			vel += new Vector3 (0, -0.03f, 0);
		}

		vel += directionVector * movementSensitivity;

		// Set rotation to the move direction
		const float maxRotationSpeed = 500;
		if (directionVector.sqrMagnitude > 0.01) {
			Vector3 newForward = ConstantSlerp (
				transform.forward,
				directionVector,
				maxRotationSpeed * Time.deltaTime
			);
			newForward = ProjectOntoPlane(newForward, transform.up);
			transform.rotation = Quaternion.LookRotation (newForward, transform.up);
		}
	}
	private void ApplyFriction () {
		vel *= friction;
	}
	private void ApplyVel () {
		// Apply stored horizontal velocity AND gravity!
		characterController.Move (new Vector3 (vel.x, GRAVITY, vel.z));
	}

	float waddleOscillation=0;
	float waddleScale=0;
	private void UpdateWaddle () {
		// Update values
		float horzVelMagnitude = Mathf.Sqrt (characterController.velocity.x*characterController.velocity.x + characterController.velocity.z*characterController.velocity.z); // We don't use y vel in calculating our walking waddle (obviously).
		waddleOscillation += horzVelMagnitude * 0.12f;
		waddleScale = Mathf.Abs (horzVelMagnitude)*0.9f;
		// Apply values!
		float waddleRotation = Mathf.Sin (waddleOscillation) * waddleScale;
		bodyMeshGO.transform.localEulerAngles = new Vector3 (bodyMeshGO.transform.localEulerAngles.x,bodyMeshGO.transform.localEulerAngles.y, waddleRotation);
	}

//	private void RegisterButtons () {
//		if (InputController.IsButtonDown_Action) { OnButtonDown_Action (); }
//	}

//	private void OnButtonDown_Action () {
//		// Carrying at least one seed?? Drop it into a SeedHole if there's one around!
//		if (seedsHolding.Count > 0) {
//			// Find the closest seedHole that we're touching
//			SeedHole seedHole = GetClosestPropTouching<SeedHole> ();
//			// Is there a SeedHole to put a seed into??
//			if (seedHole != null) {
//				PlaceSeedIntoSeedHole (seedHole);
//				return;
//			}
//		}
//		// Is this a WATER source??
////		WaterSource waterSource = GetClosestPropTouching<SeedHole> ();
////		if (
//	}




}



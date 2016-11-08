using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	// Constants
	private const string BUTTON_ACTION = "Drop"; // HACK temp test
	private const string BUTTON_DROP = "Drop";
	private const string BUTTON_PICK_UP = "PickUp";
	// Properties
//	static private bool isButtonUp_Action;
	static private bool isButtonDown_Action;
	static private bool isButtonDown_Drop;
	static private bool isButtonDown_PickUp;
	static private bool isButtonDown_JoystickLClick;
	static private bool isButtonDown_JoystickRClick;
	static private bool isPlayerAxisInput; // true if playerAxisInput's magnitude isn't 0!
	static private Vector2 joystickLAxis;
	static private Vector2 joystickRAxis;
	static private Vector2 playerAxisInput;

	// Getters
//	static public bool IsButtonUp_Action   { get { return isButtonUp_Action; } }
	static public bool IsButtonDown_Action { get { return isButtonDown_Action; } }
	static public bool IsButtonDown_Drop { get { return isButtonDown_Drop; } }
	static public bool IsButtonDown_PickUp { get { return isButtonDown_PickUp; } }
	static public bool IsButtonDown_JoystickLClick { get { return isButtonDown_JoystickLClick; } }
	static public bool IsButtonDown_JoystickRClick { get { return isButtonDown_JoystickRClick; } }
	static public bool IsPlayerAxisInput { get { return isPlayerAxisInput; } }
	static public Vector2 JoystickLAxis { get { return joystickLAxis; } }
	static public Vector2 JoystickRAxis { get { return joystickRAxis; } }
	static public Vector2 PlayerAxisInput { get { return playerAxisInput; } }


	static private float frameTimeScale; // TODO: Get this out of this class, yo!
	static private float frameTimeScaleUnscaled; // TODO: Get this out of this class, yo!
	static public float FrameTimeScale { get { return frameTimeScale; } }
	static public float FrameTimeScaleUnscaled { get { return frameTimeScaleUnscaled; } }


	// ----------------------------------------------------------------
	//  Awake
	// ----------------------------------------------------------------
//	private void Awake () {
//		// There can only be one (instance)!!
//		if (instance != null) {
//
//		}
//	}


	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		frameTimeScale = GameProperties.TARGET_FRAME_RATE * Time.deltaTime;
		frameTimeScaleUnscaled = GameProperties.TARGET_FRAME_RATE * Time.unscaledDeltaTime;

		RegisterButtonInputs ();
	}

	private void RegisterButtonInputs () {
//		isButtonUp_Action   = Input.GetButtonUp (BUTTON_ACTION);
		isButtonDown_Action = Input.GetButtonDown (BUTTON_ACTION);
		isButtonDown_Drop = Input.GetButtonDown (BUTTON_DROP);
		isButtonDown_PickUp = Input.GetButtonDown (BUTTON_PICK_UP);
		isButtonDown_JoystickLClick = Input.GetButtonDown ("JoystickAClick");
		isButtonDown_JoystickRClick = Input.GetButtonDown ("JoystickBClick");
		joystickLAxis = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		joystickRAxis = new Vector2 (Input.GetAxisRaw ("HorizontalB"), Input.GetAxisRaw ("VerticalB"));
		playerAxisInput = joystickLAxis;
		isPlayerAxisInput = playerAxisInput.x!=0 || playerAxisInput.y!=0;
	}


}



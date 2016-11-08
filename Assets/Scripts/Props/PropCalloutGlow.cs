using UnityEngine;
using System.Collections;

public class PropCalloutGlow : MonoBehaviour {
	// Constants
	private const float intensityMin = 0.6f;
	private const float intensityMax = 2f;
	// Components
	[SerializeField] private new Light light;
	// Properties
	private float oscillationCount;



	// ----------------------------------------------------------------
	//  Awake
	// ----------------------------------------------------------------
	private void Awake () {
		Hide ();
	}


	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	public void Show () {
		light.enabled = true;
		oscillationCount = 0;
	}
	public void Hide () {
		light.enabled = false;
	}



	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		if (light.enabled) {
			// Oscillate light intensity!
			oscillationCount += Time.deltaTime * 12f;
			float lerpLoc = Mathf.Sin (oscillationCount)*0.5f + 0.5f;
			light.intensity = Mathf.Lerp (intensityMin, intensityMax, lerpLoc);
		}
	}


}



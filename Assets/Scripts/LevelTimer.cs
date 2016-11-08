using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour {
	// Properties
	private float timeTotal = 361; // in SECONDS, how long we have TOTAL to play this level.
	private float timeLeft; // in SECONDS. This counts down to 0.
	// References
	[SerializeField] private GameController gameControllerRef;
	[SerializeField] private Text timerText;


	// Getters
	private string GetSecondsToTimeString (float _totalSeconds) {
		string minutes = Mathf.Floor (_totalSeconds / 60).ToString("0");
		string seconds = Mathf.Floor (_totalSeconds % 60).ToString("00");
		return minutes + ":" + seconds;
	}


	// ----------------------------------------------------------------
	//  Resetting
	// ----------------------------------------------------------------
	public void ResetTimer () {
		// Reset values!
		SetTimeLeft (timeTotal);
	}



	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	private void SetTimeLeft (float _timeLeft) {
		// Update value
		timeLeft = _timeLeft;
		// Apply updated text!
		ApplyTimerText ();
	}
	private void ApplyTimerText () {
		timerText.text = GetSecondsToTimeString (timeLeft);
	}



	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	private void OnOutOfTime () {
		// Force timeLeft down to 0.
		SetTimeLeft (0);
		// Tell gameController!
		gameControllerRef.OnOutOfTime ();
	}



	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		// If we're PLAYING...!
		if (gameControllerRef.GameState == GameState.Playing) {
			// Countdown!!
			SetTimeLeft (timeLeft - Time.deltaTime);
			// Out of time?!
			if (timeLeft <= 0) {
				OnOutOfTime ();
			}
		}
	}

}



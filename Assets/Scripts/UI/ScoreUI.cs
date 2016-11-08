using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {
	// Components
	[SerializeField] private Text scoreText;


	// ----------------------------------------------------------------
	//  Start / Destroy
	// ----------------------------------------------------------------
	private void Start () {
		// Add event listeners!
		GameManagers.Instance.EventManager.ScoreChangedEvent += OnScoreChanged;
	}
	private void OnDestroy () {
		// Remove event listeners!
		GameManagers.Instance.EventManager.ScoreChangedEvent -= OnScoreChanged;
	}


	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	private void OnScoreChanged (int score) {
		// Update scoreText!
		scoreText.text = score.ToString ();
	}


}



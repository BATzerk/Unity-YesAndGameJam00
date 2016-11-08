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
//		GameManagers.Instance.EventManager.NumNuggetsCollectedChangedEvent += OnNumNuggetsCollectedChanged;
	}
	private void OnDestroy () {
		// Remove event listeners!
//		GameManagers.Instance.EventManager.NumNuggetsCollectedChangedEvent -= OnNumNuggetsCollectedChanged;
	}


	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
//	private void OnNumNuggetsCollectedChanged (int numNuggetsCollected) {
//		// Update scoreText!
//		scoreText.text = numNuggetsCollected.ToString ();
//	}


}



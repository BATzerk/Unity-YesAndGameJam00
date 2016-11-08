using UnityEngine;
using System.Collections;

public class SausageEater : MonoBehaviour {
	// Components
	[SerializeField] private AudioSource audioSource_eatSausage;
	// References
	[SerializeField] private GameController gameControllerRef;
	[SerializeField] private EffectsController effectsControllerRef;




	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	private void EatSausage (GameObject sausageGO) {
		// Particle effects!
		effectsControllerRef.OnCollectSausage (sausageGO.transform.localPosition + sausageGO.transform.parent.localPosition); // HACK yo
		// Score!
		gameControllerRef.Score ++;
		// Play sfx!
		audioSource_eatSausage.pitch = Random.Range (0.9f, 1.1f);
		audioSource_eatSausage.Play ();
		// FOR NOW, just destroy the sausage
		Destroy (sausageGO.transform.parent.gameObject); // HACK! Sausage collider must be in a child of the sausage.
	}


	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	private void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == Tags.SAUSAGE) {
			// EAT THE SAUSAGE!
			EatSausage (col.gameObject);
		}
	}


}



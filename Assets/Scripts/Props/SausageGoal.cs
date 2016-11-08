using UnityEngine;
using System.Collections;

public class SausageGoal : MonoBehaviour {
	// Components
	private AudioSource audioSource;


	private void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}



	private void CollectSausage (GameObject sausageGO) {
		// Play sfx!
		audioSource.pitch = Random.Range (0.9f, 1.1f);
		audioSource.Play ();
		// FOR NOW, just destroy the sausage
		Destroy (sausageGO.transform.parent.gameObject); // HACK! Sausage collider must be in a child of the sausage.
	}


	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	private void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == Tags.SAUSAGE) {
			CollectSausage (col.gameObject);
		}
	}

}

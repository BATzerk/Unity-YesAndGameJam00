using UnityEngine;
using System.Collections;

public class SausageGoal : MonoBehaviour {



	private void CollectSausage (GameObject sausageGO) {
		// FOR NOW, just destroy the sausage
		Destroy (sausageGO);
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

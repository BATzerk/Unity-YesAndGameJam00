using UnityEngine;
using System.Collections;

public class Sausage : MonoBehaviour {
	// References
	[SerializeField] private AudioSource audioSource;


	private void OnCollisionEnter (Collision col) {
		audioSource.volume = Mathf.Min (1.3f, col.impulse.magnitude) * 1.2f;
		audioSource.pitch = Random.Range (0.8f, 1.2f);
		audioSource.Play ();
	}

}



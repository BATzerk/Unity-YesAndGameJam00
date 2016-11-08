using UnityEngine;
using System.Collections;

public class EffectsController : MonoBehaviour {
	// References
	[SerializeField] private ParticleSystem particles_collectSausage;



	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	public void OnCollectSausage (Vector3 pos) {
		particles_collectSausage.transform.localPosition = pos;
		particles_collectSausage.Emit (100);
	}


}



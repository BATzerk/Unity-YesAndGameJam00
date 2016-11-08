using UnityEngine;
using System.Collections;

public class PlayerBodyTrigger : PropTrigger {
	// References
	private Player myPlayer; // set from myProp.


	// Getters
	private Prop GetPropFromCollider (Collider col) {
		if (col.GetComponent<PropTrigger> () != null) {
			return col.GetComponent<PropTrigger> ().MyProp;
		}
		return null;
	}


	// ----------------------------------------------------------------
	//  Start
	// ----------------------------------------------------------------
	private void Start () {
		// Set myPlayer!
		myPlayer = MyProp as Player;
	}



	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	private void OnTriggerEnter (Collider col) {
		// What was it!
		Prop prop = GetPropFromCollider (col);
//		if (prop is Flower) {
//			myPlayer.OnTouchFlower (prop as Flower);
//		}
	}


}



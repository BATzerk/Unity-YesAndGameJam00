using UnityEngine;
using System.Collections;

/** This useful class is an easy way to A) Tell a Prop about trigger events, and B) Ask a trigger for its prop. */
public class PropTrigger : MonoBehaviour {
	// References
	[SerializeField] private Prop myProp;

	// Getters / Setters
	public Prop MyProp { get { return myProp; } }
	public void SetMyProp (Prop _prop) {
		if (myProp!=null) { Debug.LogError ("Oops! Trying to set a PropTrigger's Prop, but it's already got one!"); return; }
		myProp = _prop;
	}


	private void OnTriggerEnter (Collider col) { myProp.OnTriggerEnter (col); }


}

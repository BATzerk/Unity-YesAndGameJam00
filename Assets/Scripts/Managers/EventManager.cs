using UnityEngine;
using System.Collections;

public class EventManager {
	// Events
	public delegate void IntAction (int _int);
	public delegate void PropAction (Prop prop);
	public delegate void Vector3Action (Vector3 vector);

	public event IntAction ScoreChangedEvent;
	public event PropAction PropDiedEvent;
	public event PropAction PropExhaustedEvent;


	// Things-that-happen Events
	public void OnScoreChanged (int score) { if (ScoreChangedEvent!=null) { ScoreChangedEvent (score); } }
	public void OnPropDied (Prop prop) { if (PropDiedEvent!=null) { PropDiedEvent (prop); } }
	public void OnPropExhausted (Prop prop) { if (PropExhaustedEvent!=null) { PropExhaustedEvent (prop); } }

	// Doer events
//	public Seed SpawnSeed (Vector3 pos) { return SpawnSeedEvent (pos); } // if (SpawnSeedEvent!=null) { 



}





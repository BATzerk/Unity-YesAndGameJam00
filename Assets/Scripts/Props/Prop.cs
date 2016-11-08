using UnityEngine;
using System.Collections;

public class Prop : MonoBehaviour {
	// Overridable properties
	virtual protected bool HasProgressBar { get { return false; } } // override this if you want a ProgressBar!
	virtual protected Vector3 ProgressBarPos { get { return new Vector3 (0, 0.5f, 0); } }
	virtual public float CursorDiameter { get { return 1f; } } // In Unity units.
	virtual public bool CanInteractWithProp (Prop _prop) { return false; }

	// Components
	protected ProgressBar progressBar; // a Prop having a ProgressBar is totally optional. Lots of props don't.
	// Properties


	// Getters
	protected float fts { get { return InputController.FrameTimeScale; } }
	protected float frameTimeScaleUnscaled { get { return InputController.FrameTimeScaleUnscaled; } }
	public Vector3 Pos { get { return this.transform.localPosition; } }
	protected T GetPropFromCollider<T> (Collider col) where T : Prop {
		if (col.GetComponent<PropTrigger> () != null) {
			return col.GetComponent<PropTrigger> ().MyProp as T;
		}
		return null;
	}



	// ----------------------------------------------------------------
	//  Start
	// ----------------------------------------------------------------
	virtual protected void Awake () {
		if (HasProgressBar) {
			AddProgressBar ();
		}
	}
	private void AddProgressBar () {
//		progressBar = Instantiate (PropAdder.Prefab_progressBar).GetComponent<ProgressBar> (); QQQ
//		progressBar.Initialize (this.transform);
//		progressBar.transform.localPosition = ProgressBarPos;
	}

	protected void SetMyParent (Transform _parentTransform, Vector3 _myPos) {
		this.transform.SetParent (_parentTransform);
		this.transform.localPosition = _myPos;
		this.transform.localScale = Vector3.one;
	}


	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	virtual public void DirectToPos (Vector3 _pos) { }
	virtual public void DirectToProp (Prop _otherProp) { }
	protected void Die () {
		// Tell everyone I'm Felicia.
		GameManagers.Instance.EventManager.OnPropDied (this);
		// TODO: Some sort of particle effect, etc.?
		this.gameObject.SetActive (false);
	}



	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	virtual public void OnTriggerEnter (Collider col) { }




	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
//	virtual protected void Update () {
//	
//	}


}


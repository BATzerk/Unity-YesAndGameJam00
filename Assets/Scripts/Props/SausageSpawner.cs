using UnityEngine;
using System.Collections;

public class SausageSpawner : MonoBehaviour {
	// Constants
	private float SPAWN_INTERVAL = 10f;
	// Prefabs
	[SerializeField] private GameObject sausagePrefab;
	// Properties
	private float timeUntilSpawnSausage;


	private void Awake () {
		timeUntilSpawnSausage = Random.Range (0, SPAWN_INTERVAL);
	}


	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	private void SpawnSausage () {
		GameObject sausageGO = Instantiate<GameObject> (sausagePrefab);
		sausageGO.transform.SetParent (this.transform.parent);
		sausageGO.transform.localPosition = this.transform.localPosition;
		sausageGO.transform.localEulerAngles = new Vector3 (Random.Range (-90, 90), Random.Range (-90, 90), Random.Range (-90, 90));
		float angleY = this.transform.localEulerAngles.y * Mathf.Deg2Rad;
		Vector3 force = new Vector3 (Mathf.Sin (angleY), 0.25f, Mathf.Cos (angleY) * 100);
		sausageGO.GetComponentInChildren<Rigidbody> ().AddForce (force);
		timeUntilSpawnSausage = SPAWN_INTERVAL;
	}



	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		// Countdown to adding sausage!
		timeUntilSpawnSausage -= Time.deltaTime;
		if (timeUntilSpawnSausage <= 0) {
			SpawnSausage ();
		}
	}


}




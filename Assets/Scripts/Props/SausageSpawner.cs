using UnityEngine;
using System.Collections;

public class SausageSpawner : MonoBehaviour {
	// Constants
	private float SPAWN_INTERVAL = 10f;
	// Prefabs
	[SerializeField] private GameObject sausagePrefab;
	// Properties
	private float timeUntilSpawnSausage;



	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	private void SpawnSausage () {
		GameObject sausageGO = Instantiate<GameObject> (sausagePrefab);
		sausageGO.transform.SetParent (this.transform.parent);
		sausageGO.transform.localPosition = this.transform.localPosition;
		sausageGO.transform.localEulerAngles = new Vector3 (Random.Range (-90, 90), Random.Range (-90, 90), Random.Range (-90, 90));
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




using UnityEngine;
using System.Collections;

public class PropAdder : MonoBehaviour {
	// References
	[SerializeField] private GameObject levelGO;

	// Prefabs
//	static private GameObject prefab_xyz;
//	static public GameObject Prefab_xyz { get { if (prefab_flower==null) { prefab_flower = Resources.Load<GameObject> (GameProperties.PATH_GAME_OBJECTS + "Flower"); } return prefab_flower; } }


	// ----------------------------------------------------------------
	//  Start / Destroy
	// ----------------------------------------------------------------
	private void Awake () {
		// Add event listeners!
//		GameManagers.Instance.EventManager.SpawnSeedEvent += SpawnSeed;
	}
	private void OnDestroy () {
		// Remove event listeners!
//		GameManagers.Instance.EventManager.SpawnSeedEvent -= SpawnSeed;
	}


	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
//	private Seed SpawnSeed (Vector3 pos) {
//		int type = SeedTypes.NORMAL; // TEMP for now. All seeds are da same.
////		GameObject prefabGO = Resources.Load<GameObject> (GameProperties.PATH_GAME_OBJECTS + "Seed_" + SeedTypes.GetNameFromType (type));
//		Seed obj = Instantiate (Prefab_seed).GetComponent<Seed> ();
//		obj.Initialize (levelGO.transform, pos, type);
//		return obj;
//	}


}




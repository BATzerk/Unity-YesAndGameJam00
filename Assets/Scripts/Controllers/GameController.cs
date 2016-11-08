using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	// Properties
	private GameState gameState;
	private int score;
	// References
	[SerializeField] private LevelTimer levelTimer;
	[SerializeField] private Player player;

	// Getters / Setters
	public GameState GameState { get { return gameState; } }
	public int Score {
		get { return score; }
		set {
			score = value;
			GameManagers.Instance.EventManager.OnScoreChanged (score);
		}
	}



	// ----------------------------------------------------------------
	//  Start / Destroy
	// ----------------------------------------------------------------
	private void Start () {
		// Set application values
		Application.targetFrameRate = GameProperties.TARGET_FRAME_RATE;

		// Reset things!
		gameState = GameState.Playing;
		Score = 0;
		levelTimer.ResetTimer ();
	}



	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	private void ReloadScene () {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("LevelTest");//SceneNames.LEVEL1);
	}
	private void TogglePause () {
		// HACKED in for now
		if (Time.timeScale < 0.5f) { Time.timeScale = 1; }
		else { Time.timeScale = 0; }
	}



	// ----------------------------------------------------------------
	//  Events
	// ----------------------------------------------------------------
	public void OnOutOfTime () {
		gameState = GameState.GameOver;
	}



	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		RegisterButtonInput ();
		// TEMP TEMP
		if (Input.GetKey (KeyCode.F)) {
			Time.timeScale = 5f;
		}
		if (Input.GetKeyUp (KeyCode.F)) {
			Time.timeScale = 1;
		}
	}
	private void RegisterButtonInput () {
		// ENTER = Start a new game
		if (Input.GetKeyDown (KeyCode.Return)) {
			ReloadScene ();
		}
		// ESC or P = Pause
		else if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
			TogglePause ();
		}
	}






}



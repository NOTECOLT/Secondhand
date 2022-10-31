using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour {
	// SINGLETON PATTERN
	private static GameSceneManager _instance;
	public static GameSceneManager Instance { get {return _instance; } }

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	public GameState state;
	public GameObject mainRoomCanvas;
	public GameObject mainRoomScroll;
	public GameObject repairRoomCanvas;
	public GameObject repairRoomScroll;
	public GameObject washingMinigameCanvas;


	public bool gamePaused = false;
	public GameObject pauseMenu;

	private void Start() {
		SetState(GameState.MainRoom);
		TogglePauseGame(false);
	}

	private void Update() {
		if (Input.GetKeyUp(KeyCode.Escape))
			TogglePauseGame(!gamePaused);
	}

	public void SetState(GameState s) {
		state = s;

		switch(s) {
			case GameState.MainRoom:
				mainRoomCanvas.SetActive(true);
				mainRoomScroll.SetActive(true);

				repairRoomCanvas.SetActive(false);
				repairRoomScroll.SetActive(false);

				washingMinigameCanvas.SetActive(false);
				break;
			case GameState.RepairRoom:
				mainRoomCanvas.SetActive(false);
				mainRoomScroll.SetActive(false);

				repairRoomCanvas.SetActive(true);
				repairRoomScroll.SetActive(true);

				washingMinigameCanvas.SetActive(false);
				break;
			case GameState.WashMinigame:
				mainRoomCanvas.SetActive(false);
				mainRoomScroll.SetActive(false);
				
				repairRoomCanvas.SetActive(false);
				repairRoomScroll.SetActive(false);

				washingMinigameCanvas.SetActive(true);
				break;
			default:
				return;
		}
	}

	public void TogglePauseGame(bool state) {
		pauseMenu.SetActive(state);
		gamePaused = state;
	}
}

[System.Serializable]
public enum GameState {
	MainRoom,
	RepairRoom,
	WashMinigame
}

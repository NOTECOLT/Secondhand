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

	private void Start() {
		state = GameState.MainRoom;
		mainRoomCanvas.SetActive(true);
	}

	public void SetState(GameState s) {
		state = s;

		switch(s) {
			case GameState.MainRoom:
				mainRoomCanvas.SetActive(true);
				mainRoomScroll.SetActive(true);

				repairRoomCanvas.SetActive(false);
				repairRoomScroll.SetActive(false);
				break;
			case GameState.RepairRoom:
				mainRoomCanvas.SetActive(false);
				mainRoomScroll.SetActive(false);

				repairRoomCanvas.SetActive(true);
				repairRoomScroll.SetActive(true);
				break;
			default:
				return;
		}
	}
}

[System.Serializable]
public enum GameState {
	MainRoom,
	RepairRoom
}

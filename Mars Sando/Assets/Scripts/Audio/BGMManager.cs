using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {
	private static BGMManager _instance;
	private void Awake() {
		DontDestroyOnLoad(this);
		if (_instance == null) {
			_instance = this;
		} else {
			Destroy(gameObject);
		}
	}
}

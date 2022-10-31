using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
	// SINGLETON PATTERN
	private static SFXManager _instance;
	public static SFXManager Instance { get {return _instance; } }

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	private AudioSource _as;

	private void Start() {
		_as = GetComponent<AudioSource>();
	}

	public void PlaySFX(AudioClip sfx) {
		_as.clip = sfx;
		_as.Play();
	}

}

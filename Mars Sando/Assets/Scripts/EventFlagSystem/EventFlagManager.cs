using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFlagManager : MonoBehaviour {
	// Singleton class used for passing all Event Flags. Couples with the EventFlagListener class.
	// Stolen from Help Me Find My Doll Code lmao
	
	// SINGLETON PATTERN
	private static EventFlagManager _instance;
	public static EventFlagManager Instance { get {return _instance; } }

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	private Dictionary<string, bool> _flagDict = new Dictionary<string, bool>();
	public string[] flagList;   // Used for creating the list of flags.
	public event Action<string> onFlagTickTrue;

	private void Start() {
		// Each flag in flagList gets added to the _flagDict Dictionary.
		foreach (string entry in flagList) {
			_flagDict.Add(entry, false);
		}
	}

	public void FlagTickTrue(string flagName) {
		if (!_flagDict.ContainsKey(flagName)) {
			Debug.LogWarning("Flag Name " + flagName + " does not exist within Flag List Dictionary!");
			return;
		}

		print("Flag Called: " + flagName);   
		_flagDict[flagName] = true;

		if (onFlagTickTrue == null) {
			return;
		}

		onFlagTickTrue(flagName);
	}

	public bool GetFlagValue(string flagName) {
		if (!_flagDict.ContainsKey(flagName)) {
			Debug.LogWarning("Flag Name " + flagName + " does not exist within Flag List Dictionary!");
			return false;
		}

		return _flagDict[flagName];
	}

	public bool CheckFlagsList(List<string> flagList) {
		foreach (string s in flagList) {
			Debug.Log(s + " " + GetFlagValue(s));
			if (!GetFlagValue(s))
				return false;
		}

		return true;
	}
}

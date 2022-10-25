using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventFlagListener : MonoBehaviour {
	// Dedicated Listener Class for EventFlags. Will call any specified function once a flag has been ticked.
	// Stolen from Help Me Find My Doll Code lmao

	void Start() {
		EventFlagManager.Instance.onFlagTickTrue += OnFlagTick;
	}

	public UnityEvent FlagFunction;
	public string flagNameRef;

	private void OnFlagTick(string flagName) {
		if (flagName == flagNameRef) {
			print(flagName + " event received by " + gameObject.name);
			FlagFunction.Invoke();
		} 
	}

	void OnDstroy() {
		EventFlagManager.Instance.onFlagTickTrue -= OnFlagTick;
	}
}

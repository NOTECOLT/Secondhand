using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Clickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	// Generic MonoBehaviour Class for items that are clickable.
	// Stolen from Help Me Find My Doll Code lmao

	public bool enableClicking = true;
	public UnityEvent<PointerEventData> OnPointerDownFunction;
	public UnityEvent<PointerEventData> OnPointerUpFunction;


	public virtual void OnPointerDown(PointerEventData eventData) {
		if (enableClicking)
			OnPointerDownFunction.Invoke(eventData);
	}
	public virtual void OnPointerUp(PointerEventData eventData) {
		if (enableClicking) {
			OnPointerUpFunction.Invoke(eventData);
		}  
	}

	public void SetClicking(bool value) {
		enableClicking = value;
	}


	// Just For Debugging Purposes
	public void Message(string msg) {
		Debug.Log(msg);
	}
}

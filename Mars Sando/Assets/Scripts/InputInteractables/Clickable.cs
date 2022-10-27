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
		if (!enableClicking) return;

		OnPointerDownFunction.Invoke(eventData);
		// if (gameObject.GetComponent<Interactable>() != null)
		// 	gameObject.GetComponent<Interactable>().OnClick();
	}
	public virtual void OnPointerUp(PointerEventData eventData) {
		if (!enableClicking) return;
		
		OnPointerUpFunction.Invoke(eventData);
		if (gameObject.GetComponent<Interactable>() != null)		
			gameObject.GetComponent<Interactable>().OnClick();
		// When an Interactable.cs component is attached, the OnClick function will play, and all
		// interactable logic will feed thru there
	}

	public void SetClicking(bool value) {
		enableClicking = value;
	}
}

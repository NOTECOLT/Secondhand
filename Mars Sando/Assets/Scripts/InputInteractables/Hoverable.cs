using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public bool enableHovering = true;
	public bool isHovering = false;

	public UnityEvent<PointerEventData> OnPointerEnterFunction;
	public UnityEvent<PointerEventData> OnPointerExitFunction;

	public virtual void OnPointerEnter(PointerEventData eventData) {
		if (!enableHovering)
			return;

		OnPointerEnterFunction.Invoke(eventData);
		isHovering = true;

		if (gameObject.GetComponent<Interactable>() != null)		
			gameObject.GetComponent<Interactable>().OnEnterHover();
	}

	public virtual void OnPointerExit(PointerEventData eventData) {
		if (!enableHovering)
			return;

		OnPointerExitFunction.Invoke(eventData);
		isHovering = false;   

		if (gameObject.GetComponent<Interactable>() != null)		
			gameObject.GetComponent<Interactable>().OnExitHover(); 
	}

	public void SetHovering(bool value) {
		enableHovering = value;
		isHovering = false;
	}
}

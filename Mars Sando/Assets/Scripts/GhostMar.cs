using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostMar : MonoBehaviour {

	public Sprite phase2;
	public Vector2 phase2size;
	public Sprite phase3;
	public Vector2 phase3size;

	public void ChangeToPhase1() {
		GetComponent<Image>().enabled = true;
	}

	public void ChangeToPhase2() {
		GetComponent<Image>().sprite = phase2;
		GetComponent<RectTransform>().sizeDelta = phase2size;
	}

	public void ChangeToPhase3() {
		GetComponent<Image>().sprite = phase3;
		GetComponent<RectTransform>().sizeDelta = phase3size;
	}
}

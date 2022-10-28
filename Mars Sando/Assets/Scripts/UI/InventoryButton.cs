using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {
	public GameObject invPanel;
	[SerializeField] private bool _invShown = false;
	public void OnButtonClick() {
		if (_invShown) {
			_invShown = false;
			invPanel.GetComponent<Animator>().SetTrigger("Slide Up");
		} else {
			_invShown = true;
			invPanel.GetComponent<Animator>().SetTrigger("Slide Down");
		}
	}
}

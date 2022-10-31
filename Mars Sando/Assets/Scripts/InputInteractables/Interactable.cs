using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
	public List<Interaction> interactions;

	public void OnEnterHover() {
		if (GetComponent<Outline>() != null)
			GetComponent<Outline>().enabled = true;
	}

	public void OnExitHover() {
		if (GetComponent<Outline>() != null)
			GetComponent<Outline>().enabled = false;
	}

	public void OnClick() {
		for (int i = 0; i < interactions.Count; i++) {
			if (EventFlagManager.Instance.CheckFlags(interactions[i].flagChecks) &&
				InventoryManager.Instance.CheckItems(interactions[i].itemChecks)) {

				if (interactions[i].useItem != null && InventoryManager.Instance.selectedItem != interactions[i].useItem)
					continue;
					
				if (interactions[i].dialogue.sentences.Length != 0 && GetComponent<DialogueCaller>() != null)
					GetComponent<DialogueCaller>().CallDialogue(interactions[i].dialogue);
				interactions[i].action.Invoke();

				return;
			}
		}

		if (GetComponent<DialogueCaller>() != null)
			GetComponent<DialogueCaller>().CallDialogue();
		return;
	}

	public void ChangeSprite(Sprite sprite) {
		GetComponent<Image>().sprite = sprite;
	}

	public void DestroySelf() {
		Destroy(gameObject);
	}
}

[System.Serializable]
public class Interaction {
	// An interaction checks for the appropriate flags & items before displaying dialogue & doing actions
	public List<FlagCheck> flagChecks;
	public List<ItemCheck> itemChecks;
	public Item useItem = null;
	public Dialogue dialogue;
	public UnityEvent action;
}
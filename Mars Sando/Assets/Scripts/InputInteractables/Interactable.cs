using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {
	public List<Interaction> interactions;


	// When arranging Interactions, put later-game interactions to the front
	public void OnClick() {
		for (int i = 0; i < interactions.Count; i++) {
			if (EventFlagManager.Instance.CheckFlagsList(interactions[i].flagChecks) &&
				InventoryManager.Instance.HasItems(interactions[i].itemChecks)) {
					
				if (interactions[i].dialogue != null && GetComponent<DialogueCaller>() != null)
					GetComponent<DialogueCaller>().CallDialogue(interactions[i].dialogue);
				interactions[i].action.Invoke();

				// if (interactions[i].isOneTime) {
				// 	interactions.Remove(interactions[i]);
				// 	i--;
				// }

				return;
			}
		}

		if (GetComponent<DialogueCaller>() != null)
			GetComponent<DialogueCaller>().CallDialogue();
		return;
	}
}

[System.Serializable]
public class Interaction {
	// An interaction checks for the appropriate flags & items before displaying dialogue & doing actions
	public List<string> flagChecks;
	public List<Item> itemChecks;
	public Dialogue dialogue;
	public UnityEvent action;
	// public bool isOneTime = false;
}
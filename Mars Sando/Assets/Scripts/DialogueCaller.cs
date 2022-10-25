using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour {
	// Attached to interactable objects, allows them to start dialogue with the dialogue manager
    public Dialogue dialogue;

    public void CallDialogue() {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour {
	// Attached to interactable objects, allows them to start dialogue with the dialogue manager
    public Dialogue defaultDialogue = new Dialogue(new string[] {"I don't think I need that right now..."});

    public void CallDialogue(Dialogue dialogue = null) {
        if (dialogue == null) dialogue = defaultDialogue;
        DialogueManager.Instance.StartDialogueAuto(dialogue);
    }

    public void CallDialogue() {
        DialogueManager.Instance.StartDialogueAuto(defaultDialogue);
    }
}

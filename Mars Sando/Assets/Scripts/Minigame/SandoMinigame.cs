using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandoMinigame : MonoBehaviour {
    public Dialogue onWashMGDoneDialogue;
    public Transform dirtPatches;
    public Sprite phase3;
    public void CheckWashingMGStatus() {
        if (dirtPatches.childCount == 1) {
            EventFlagManager.Instance.FlagTickTrue("sando/phase2/clean");
            GetComponent<DialogueCaller>().CallDialogue(onWashMGDoneDialogue);

            if (EventFlagManager.Instance.GetFlagValue("sando/phase2/sewed")) {
                GetComponent<Image>().sprite = phase3;
            }
        }
    }

    public void CheckSewingMGStatus() {
        
    }
}

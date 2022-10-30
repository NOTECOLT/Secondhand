using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandoWashMG : MonoBehaviour {
    public Dialogue onWashMGDoneDialogue;
    public Transform dirtPatches;
    
    public void CheckWashingMGStatus() {
        if (dirtPatches.childCount == 1) {
            EventFlagManager.Instance.FlagTickTrue("sando/phase2/clean");
            GetComponent<DialogueCaller>().CallDialogue(onWashMGDoneDialogue);
            gameObject.SetActive(false);
        }
    }
}

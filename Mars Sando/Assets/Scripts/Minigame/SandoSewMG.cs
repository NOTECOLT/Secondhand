using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandoSewMG : MonoBehaviour {
    public Dialogue onSewMGDoneDialogue;
    public Sprite phase3;
    private int _patchedCount = 4;

    public void CheckSewingMGStatus() {
        if (_patchedCount > 0)
            _patchedCount--;
        
        if (_patchedCount == 0) {
            EventFlagManager.Instance.FlagTickTrue("sando/phase2/sewed");
            GetComponent<DialogueCaller>().CallDialogue(onSewMGDoneDialogue);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatchSew : MonoBehaviour {
    public Sprite sewedSprite;
    private bool _isSewn = false;

    public void SewPatch() {
        if (!_isSewn) {
            GetComponent<Image>().sprite = sewedSprite;
            _isSewn = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCaller : MonoBehaviour {
    public AudioClip clip;

    public void PlaySFX() {
        SFXManager.Instance.PlaySFX(clip);
    }
}

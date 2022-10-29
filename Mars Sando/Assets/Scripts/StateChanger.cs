using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour {
    public GameState state;
    public void SetState() {
        GameSceneManager.Instance.SetState(state);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairRoomButton : MonoBehaviour {
    public void OnClick() {
        GameSceneManager.Instance.SetState(GameState.MainRoom);
    }
}

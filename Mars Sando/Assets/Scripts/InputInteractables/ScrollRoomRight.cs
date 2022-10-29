using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRoomRight : Hoverable {
	public GameObject worldObj;
	public int scrollSpeed = 300;
	public GameObject button;
	public Sprite altSprite;
    public GameObject goText;
	private Sprite _ogSprite;
	private RectTransform _wrldTrans;
	private void Start() {
		_wrldTrans = worldObj.GetComponent<RectTransform>();
		_ogSprite = button.GetComponent<Image>().sprite;
	}

	private void Update() {
		float rightBound = (Camera.main.ScreenToViewportPoint(_wrldTrans.offsetMax)).x;

		if (isHovering) {
			if (rightBound > 0) {
                _wrldTrans.position += new Vector3(-scrollSpeed, 0, 0) * Time.deltaTime;
                button.GetComponent<Clickable>().enableClicking = false;
                goText.SetActive(false);
            } else {
                button.GetComponent<Clickable>().enableClicking = true;
                goText.SetActive(true);
            }
            
			button.GetComponent<Image>().sprite = altSprite;
		} else {
			button.GetComponent<Image>().sprite = _ogSprite;
            goText.SetActive(false);
		}
	}

	public void ToRepairRoom() {
		isHovering = false;
		GameSceneManager.Instance.SetState(GameState.RepairRoom);
	}
}

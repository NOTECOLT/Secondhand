using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRoomLeft : Hoverable {
	public GameObject worldObj;
	public int scrollSpeed = 300;
	public GameObject button;
	public Sprite altSprite;
	private Sprite _ogSprite;
	private RectTransform _wrldTrans;
	private void Start() {
		_wrldTrans = worldObj.GetComponent<RectTransform>();
		_ogSprite = button.GetComponent<Image>().sprite;
	}

	private void Update() {
		float leftBound = (Camera.main.ScreenToViewportPoint(_wrldTrans.offsetMin)).x;

		if (isHovering) {
			if (leftBound < 0) 
				_wrldTrans.position += new Vector3(scrollSpeed, 0, 0) * Time.deltaTime;
			button.GetComponent<Image>().sprite = altSprite;
		} else {
			button.GetComponent<Image>().sprite = _ogSprite;
		}
	}
}

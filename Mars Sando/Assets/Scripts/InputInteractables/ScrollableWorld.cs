using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollableWorld : Hoverable {

    // Public Variables
    public GameObject worldObj;
    public bool scrollLeft = false;
    public int scrollSpeed = 200;

    // Private Variables
    private RectTransform _wrldTrans;
    private void Start() {
        _wrldTrans = worldObj.GetComponent<RectTransform>();
    }

    private void Update() {
        float leftBound = (Camera.main.ScreenToViewportPoint(_wrldTrans.offsetMin)).x;
        float rightBound = (Camera.main.ScreenToViewportPoint(_wrldTrans.offsetMax)).x;

        if (isHovering) {
            if (scrollLeft) {
                if (leftBound < 0)
                    _wrldTrans.position += new Vector3(scrollSpeed, 0, 0) * Time.deltaTime;
            } else {
                if (rightBound > 0) 
                    _wrldTrans.position += new Vector3(-scrollSpeed, 0, 0) * Time.deltaTime;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {
    public Item item;
    [SerializeField] private Image _itemImg;

    public void SetItem(Item i) {
        item = i;
        gameObject.name = i.itemName;
        _itemImg.sprite = i.sprite;
    }
}

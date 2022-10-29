using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDisplay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public Item item;
    public bool itemSelected = false;
    [SerializeField] private Image _itemImg;

    public void SetItem(Item i) {
        item = i;
        gameObject.name = i.itemName;
        _itemImg.sprite = i.sprite;
    }

    private void Update() {
        if (item != null) {
            if (GetComponent<Hoverable>().isHovering || itemSelected) {
                _itemImg.sprite = item.selSprite;
            } else {
                _itemImg.sprite = item.sprite;
            }
        }

    }


    // Following code allows item to be used
    public void OnPointerDown(PointerEventData eventData) {

    }

    public void OnPointerUp(PointerEventData eventData) {
        if (itemSelected) {
            itemSelected = false;
            InventoryManager.Instance.SetSelectedItem();
        } else if (!itemSelected&& InventoryManager.Instance.selectedItem == null) {
            itemSelected = true;
            InventoryManager.Instance.SetSelectedItem(item);
        }
    }
}

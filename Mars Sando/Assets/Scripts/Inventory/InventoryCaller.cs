using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCaller : MonoBehaviour {
    // Attached to different interactables, etc. Will call functions in InventoryManager.cs
    public Item item;

    public void AddItem(bool destroySelf) {
        InventoryManager.Instance.AddItem(item);
        if (destroySelf)
            Destroy(gameObject);
    }

    public void UseItem(Item item) {
        if (InventoryManager.Instance.HasItem(item.itemName)) {
            InventoryManager.Instance.RemoveItem(item);
        }
    }
}
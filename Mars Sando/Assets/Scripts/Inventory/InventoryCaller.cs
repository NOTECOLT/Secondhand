using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCaller : MonoBehaviour {
    // Attached to different interactables, etc. Will call functions in InventoryManager.cs
    public Item item;

    public void CallAddItem() {
        InventoryManager.Instance.AddItem(item);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	// Central class for managing all inventory-related stuff. Called by InventoryCaller from diff objects.

	// SINGLETON PATTERN
	private static InventoryManager _instance;
	public static InventoryManager Instance { get {return _instance; } }

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	[SerializeField] private List<Item> _inventory = new List<Item>();

	public Transform invGrid;
	public GameObject itemDisp;

	// Checks to see if inventory has an item, reference by name (if reference by obj, just use .contains())
	public Item HasItem(string itemName) {
		foreach (Item i in _inventory) {
			if (i.itemName == itemName) {
				return i;
			}
		}

		Debug.Log("No " + itemName + "in inventory.");
		return null; 
	}

	public void AddItem(Item item) {
		if (_inventory.Contains(item))
			return;

		_inventory.Add(item);
		AddDisplay(item);
	}

	// overload for reference by item name
	public void RemoveItem(string itemName) {
		Item i = HasItem(itemName);

		if (i == null) {
			Debug.Log("No " + itemName + "in inventory.");
			return;
		} else {
			_inventory.Remove(i);
			return; 
		}
	}

	// overload for reference by item class
	public void RemoveItem(Item item) {
		if (_inventory.Contains(item)) {
			Debug.Log("No " + item.name + "in inventory.");
			return;
		}

		_inventory.Remove(item);
	}

	public void ClearInventory() {
		_inventory.Clear();
	}

	private void AddDisplay(Item item) {
		GameObject iDisp = Instantiate(itemDisp, invGrid);
		iDisp.GetComponent<ItemDisplay>().SetItem(item);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject {
	public string itemName;
	public Sprite sprite;
}

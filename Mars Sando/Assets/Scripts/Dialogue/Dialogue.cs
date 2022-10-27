using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
	// Just a class for dialogue
	public Dialogue(string[] sentences) {
		this.sentences = sentences;
	}

	public string[] sentences;
}

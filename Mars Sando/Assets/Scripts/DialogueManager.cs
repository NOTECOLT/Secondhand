using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
	// Singleton class that manages all dialogue in the game

	[SerializeField] private GameObject dialogueBox;
	private Queue<string> _sentenceQueue;

	// SINGLETON PATTERN
	private static DialogueManager _instance;
	public static DialogueManager Instance { get {return _instance; } }

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	private void Start() {
		_sentenceQueue = new Queue<string>();
	}

	// Restarts the queue of sentence with a new dialogue object
	public void StartDialogue(Dialogue dialogue) {
		_sentenceQueue.Clear();

		foreach (string sentence in dialogue.sentences) {
			_sentenceQueue.Enqueue(sentence);
		}

		QueueNext();
	}

	// Displays the next sentence
	public void QueueNext() {
		if (_sentenceQueue.Count == 0)
			return;

		string sentence = _sentenceQueue.Dequeue();
		dialogueBox.GetComponentInChildren<TMP_Text>().text = sentence;
		//Debug.Log(sentence);
	}
}

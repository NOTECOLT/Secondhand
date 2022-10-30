using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
	// Singleton class that manages all dialogue in the game

	public GameObject dialogueBox;
	public GameObject dialogueCanvas;
	private Queue<string> _sentenceQueue;
	private bool _isTyping = false;

	public float typingSpeed = 0.025f;

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

	// Automatically writes all sentences in a dialogue object
	public void StartDialogueAuto(Dialogue dialogue) {
		// If dialogue is currently being typed, nothing should happen
		if (_isTyping)
			return;

		// Queues all the sentences in a dialogue obj
		_sentenceQueue.Clear();
		foreach (string sentence in dialogue.sentences) {
			_sentenceQueue.Enqueue(sentence);
		}

		StartCoroutine(TypeDialogue(dialogue));
	}

	IEnumerator TypeDialogue(Dialogue dialogue) {
		GameObject box = Instantiate(dialogueBox, dialogueCanvas.transform);
		TMP_Text textObj = box.GetComponentInChildren<TMP_Text>();

		while (_sentenceQueue.Count > 0) {
			_isTyping = true;

			string sentence = _sentenceQueue.Dequeue();
			yield return StartCoroutine(TypeSentence(sentence, textObj));
			yield return new WaitForSeconds(Mathf.Clamp(sentence.Length / 60, 1.0f, 10.0f));
		}

		box.GetComponent<Animator>().SetTrigger("Slide Down");

		_isTyping = false;

		yield return null;
	}

	IEnumerator TypeSentence(string sentence, TMP_Text textObj) {
		textObj.text = "";

		foreach(char c in sentence.ToCharArray()) {
			textObj.text += c;

			switch (c) {
				case ',':
					yield return new WaitForSeconds(typingSpeed * 20);
					break;
				case '.':
					yield return new WaitForSeconds(typingSpeed * 30);
					break;
				default:
					yield return new WaitForSeconds(typingSpeed);
					break;
			}	
		}
	}
}


// // Restarts the queue of sentence with a new dialogue object. Can manually display the next sentence using QueueNext()
// public void StartDialogue(Dialogue dialogue) {
// 	_sentenceQueue.Clear();

// 	foreach (string sentence in dialogue.sentences) {
// 		_sentenceQueue.Enqueue(sentence);
// 	}

// 	QueueNext();
// }

// // Displays the next sentence
// public void QueueNext() {
// 	if (_sentenceQueue.Count == 0)
// 		return;

// 	string sentence = _sentenceQueue.Dequeue();

// 	StartCoroutine(TypeSentence(sentence));
// }
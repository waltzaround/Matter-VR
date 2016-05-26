using UnityEngine;
using System.Collections;

public class KeyBehaviour : MonoBehaviour {

	private AudioSource note;
	public string noteName;
	public NoteGovernor controller;

	// Use this for initialization
	void Start () {
		note = GetComponent<AudioSource> ();
		NoteGovernor controller = gameObject.GetComponent<NoteGovernor> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("KeyNote")) {
			note.Play();
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag("KeyNote")) {
			controller.notePlaying = true;
			controller.playingNoteName = noteName;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("KeyNote")) {
			controller.notePlaying = false;
		}
	}
}

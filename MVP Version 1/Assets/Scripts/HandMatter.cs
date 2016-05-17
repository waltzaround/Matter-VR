using UnityEngine;
using System.Collections;

public class HandMatter : MonoBehaviour {

	public KeyboardNote handNote;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		KeyboardNote handNote = GetComponent<KeyboardNote> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (handNote.handNote == " ") {
			rend.enabled = true;
		} else {
			rend.enabled = false;
		}
	}
}

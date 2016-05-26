using UnityEngine;
using System.Collections;

public class HandMatter : MonoBehaviour {

	public NoteGovernor controller;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		NoteGovernor controller = gameObject.GetComponent<NoteGovernor> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (controller.playingNoteName == " ") {
			rend.enabled = true;
		} else {
			rend.enabled = false;
		}
	}
}

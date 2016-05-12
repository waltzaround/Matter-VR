using UnityEngine;
using System.Collections;

public class HandMatter : MonoBehaviour {

	public HandBehaviourV2 handNote;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		HandBehaviourV2 handNote = GetComponent<HandBehaviourV2> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (handNote.latestNote == " ") {
			rend.enabled = true;
		} else {
			rend.enabled = false;
		}
	}
}

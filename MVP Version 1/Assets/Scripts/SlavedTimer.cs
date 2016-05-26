using UnityEngine;
using System.Collections;

public class SlavedTimer : MonoBehaviour {

	public TextMesh textToDisplay;
	public NoteGovernor controller;

	// Use this for initialization
	void Start () {
		textToDisplay = gameObject.GetComponent<TextMesh> ();
		NoteGovernor controller = gameObject.GetComponent<NoteGovernor> ();
	}

	// Update is called once per frame
	void Update () {
		textToDisplay.text = controller.timerTime;
	}
}

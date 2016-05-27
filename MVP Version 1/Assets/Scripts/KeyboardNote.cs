using UnityEngine;
using System.Collections;

public class KeyboardNote : MonoBehaviour {

	public GameObject cnoteTrigger;
	public GameObject dnoteTrigger;
	public GameObject enoteTrigger;
	public GameObject fnoteTrigger;
	public GameObject gnoteTrigger;
	public GameObject anoteTrigger;
	public GameObject bnoteTrigger;
	public GameObject c2noteTrigger;
	private AudioSource cnote;
	private AudioSource dnote;
	private AudioSource enote;
	private AudioSource fnote;
	private AudioSource gnote;
	private AudioSource anote;
	private AudioSource bnote;
	private AudioSource c2note;

	// Use this for initialization
	void Start () {
		cnote = cnoteTrigger.GetComponent<AudioSource> ();
		dnote = dnoteTrigger.GetComponent<AudioSource> ();
		enote = enoteTrigger.GetComponent<AudioSource> ();
		fnote = fnoteTrigger.GetComponent<AudioSource> ();
		gnote = gnoteTrigger.GetComponent<AudioSource> ();
		anote = anoteTrigger.GetComponent<AudioSource> ();
		bnote = bnoteTrigger.GetComponent<AudioSource> ();
		c2note = c2noteTrigger.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("happening");
		if (other.gameObject.CompareTag("C")) {
			//Debug.Log ("true");
			cnote.Play();
		}
		if (other.gameObject.CompareTag("D")) {
			dnote.Play();
		}
		if (other.gameObject.CompareTag("E")) {
			enote.Play();
		}
		if (other.gameObject.CompareTag("F")) {
			fnote.Play();
		}
		if (other.gameObject.CompareTag("G")) {
			gnote.Play();
		}
		if (other.gameObject.CompareTag("A")) {
			anote.Play();
		}
		if (other.gameObject.CompareTag("B")) {
			bnote.Play();
		}
		if (other.gameObject.CompareTag("C2")) {
			c2note.Play();
		}
	}
	void OnTriggerExit(Collider other) {
		//if (other == noteTrigger.GetComponent<Collider>()) {
			//note.Stop();
		//}
	}
}

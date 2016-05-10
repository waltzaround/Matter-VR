using UnityEngine;
using System.Collections;

public class DrumBehaviour : MonoBehaviour {

	private AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (!collision.gameObject.CompareTag ("Constraint")) {
			audio.Play ();
		}
	}
}

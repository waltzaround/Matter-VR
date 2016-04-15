using UnityEngine;
using System.Collections;

public class CubeNoteBehaviour : MonoBehaviour 
{

	public int NoteToPlay;

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log ("Triggered");
		if (other.gameObject.CompareTag("Hand"))
		{
			Debug.Log (this.NoteToPlay);
			//GetComponent("audio");
			GetComponent<AudioSource>().Play ();
			// Sende la OSC
		}
	}

	void OnTriggerExit(Collider other)
	{
		GetComponent<AudioSource>().Pause ();
	}
}

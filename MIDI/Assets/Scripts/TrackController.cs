using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour {

	public AudioSource musicTrack;
	public HandButtonBehaviour Playtab;
	public HandButtonBehaviour Stoptab;
	public HandButtonBehaviour Looptab;
	public TimerController Timer;

	// Use this for initialization
	void Start () {
		AudioSource musicTrack = GameObject.Find ("AudioSource").GetComponent<AudioSource> ();
		HandButtonBehaviour Playtab = GameObject.Find ("Playtab").GetComponent<HandButtonBehaviour> ();
		HandButtonBehaviour Stoptab = GameObject.Find ("Stoptab").GetComponent<HandButtonBehaviour> ();
		HandButtonBehaviour Looptab = GameObject.Find ("Looptab").GetComponent<HandButtonBehaviour> ();
		TimerController Timer = GameObject.Find ("TimeText").GetComponent<TimerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (musicTrack.time);
		if (!musicTrack.isPlaying && Playtab.ButtonPressed == true) {
			Playtab.ButtonPressed = false;
			//Timer.stopTheClock ();
		}
		if (musicTrack.isPlaying == false && Playtab.ButtonPressed == true) {
			musicTrack.Play ();
		}
		else if (musicTrack.isPlaying == true && Playtab.ButtonPressed == false) {
			musicTrack.Pause ();
		}

		if (musicTrack.isPlaying == true && Stoptab.ButtonPressed == true) {
			musicTrack.Stop ();
		}

		if (Looptab.ButtonPressed == true) {
			musicTrack.loop = true;
		}
		else if (Looptab.ButtonPressed == false) {
			musicTrack.loop = false;
		}
			

		if (musicTrack.time <= 0.1 && musicTrack.loop == true) {
			Timer.stopTheClock ();
		}
	}
}

using UnityEngine;
using System.Collections;

public class NoteGovernor : MonoBehaviour {
	
	//Note Display variables
	public bool notePlaying;
	public string playingNoteName;

	//Timer variables
	private float millis;
	private float sec;
	private float min;
	private bool goTimer;
	public string timerTime;

	// Initialization
	void Start () {
		notePlaying = false;
		playingNoteName = " ";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (notePlaying == false) {
			playingNoteName = " ";
		}
		timerTime = min.ToString ("F0") + ":" + sec.ToString ("F0") + ":" + millis.ToString ("F0");
		if (Input.GetKeyUp (KeyCode.P) && goTimer == false) {
			goTimer = true;
		}
		else if (Input.GetKeyUp (KeyCode.P) && goTimer == true) {
			goTimer = false;
		}

		if (goTimer == true) {
			startTheClock ();
		} else {
			stopTheClock ();
		}
	}

	public void startTheClock() {
		millis += Time.deltaTime * 100;
		if (millis >= 100) {
			sec += 1;
			millis = 0;
		}
		if (sec >= 60) {
			min += 1;
			sec = 0;
		}
	}

	public void stopTheClock() {
		millis = 0;
		sec = 0;
		min = 0;
	}
}

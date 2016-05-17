using UnityEngine;
using System.Collections;

public class TimerV2 : MonoBehaviour {

	public TextMesh textToDisplay;
	private float millis;
	private float sec;
	private float min;
	public ButtonLerp playButton;
	public ButtonLerp stopButton;

	// Use this for initialization
	void Start () {
		millis = 0;
		sec = 0;
		min = 0;
		ButtonLerp playButton = gameObject.GetComponent<ButtonLerp> ();
		ButtonLerp stopButton = gameObject.GetComponent<ButtonLerp> ();
		textToDisplay = gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		textToDisplay.text = min.ToString ("F0") + ":" + sec.ToString ("F0") + ":" + millis.ToString ("F0");
		if (playButton.isPressed == true) {
			startTheClock ();
		}
		if (stopButton.isPressed == true) {
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

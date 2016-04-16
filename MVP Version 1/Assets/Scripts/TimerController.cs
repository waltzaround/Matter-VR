using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour {

	public TextMesh textToDisplay;
	private float millis;
	private float sec;
	private float min;
	public HandButtonBehaviour Playtab;
	public HandButtonBehaviour Stoptab;

	// Use this for initialization
	void Start () {
		millis = 0;
		sec = 0;
		min = 0;
		HandButtonBehaviour Playtab = GameObject.Find ("Playtab").GetComponent<HandButtonBehaviour> ();
		HandButtonBehaviour Stoptab = GameObject.Find ("Stoptab").GetComponent<HandButtonBehaviour> ();
		textToDisplay = gameObject.GetComponent<TextMesh> ();
			//gameObject.GetComponent<TextMesh> ();
			//gameObject.GetComponent("TextMesh") as TextMesh;
	}
	
	// Update is called once per frame
	void Update () {
		textToDisplay.text = min.ToString ("F0") + ":" + sec.ToString ("F0") + ":" + millis.ToString ("F0");
		if (Playtab.ButtonPressed == true) {
			startTheClock ();
		}
		if (Stoptab.ButtonPressed == true) {
			stopTheClock ();
			Playtab.ButtonPressed = false;
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
//min.ToString () + ":" + sec.ToString () + ":" + millis.ToString ()
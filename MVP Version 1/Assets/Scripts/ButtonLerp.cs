using UnityEngine;
using System.Collections;

public class ButtonLerp : MonoBehaviour {

	public Transform homepos;
	public Transform pressedpos;
	private Transform startpos;
	private Transform endpos;
	public float speed;
	private float startTime;
	private float journeyLength;
	public bool isPressed;
	public float pressdelay;
	private float delayTimer;

	// Use this for initialization
	void Start () {
		isPressed = false;
		startpos = homepos;
		endpos = homepos;
		delayTimer = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startpos.position, endpos.position, fracJourney);
	}

	void OnTriggerExit() {
		if (isPressed == false && Time.time > delayTimer) {
			startpos = homepos;
			endpos = pressedpos;
			isPressed = true;
			delayTimer = Time.time + pressdelay;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startpos.position, endpos.position);
		}

		else if (isPressed == true && Time.time > delayTimer) {
			startpos = pressedpos;
			endpos = homepos;
			isPressed = false;
			delayTimer = Time.time + pressdelay;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startpos.position, endpos.position);
		}
	}
}

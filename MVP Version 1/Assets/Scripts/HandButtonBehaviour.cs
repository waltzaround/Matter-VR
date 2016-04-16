using UnityEngine;
using System.Collections;

public class HandButtonBehaviour : MonoBehaviour {

	//public Transform Pivot;
	public GameObject Button;
	public bool ButtonPressed;
	public Transform Pressedpos;
	public Transform Homepos;
	public float pressDelay;
	private float nextPress;
	public float buttonPressInstant;
	//private float startTime;
	//private float journeyLength;
	//public float speed;

	//private bool ButtoninTransit;
	//public int RotationSpeed;
	//public int RotationDetent1;
	//public int RotationDetent2;

	void Start () {
		//rigidbody = GetComponent<Rigidbody> ();
		ButtonPressed = false;
		nextPress = 0;
		//startTime = Time.time;
		//journeyLength = Vector3.Distance(Homepos.position, Pressedpos.position);
	}
	

	/*
		if (Button.GetComponent<Rigidbody>().rotation.x > RotationDetent1 && RotationSpeed > 0) 
		{
			Debug.Log ("STOP");
			ButtoninTransit = false;
		}
		if (Button.GetComponent<Rigidbody>().rotation.x < RotationDetent2 && RotationSpeed < 0) 
		{
			Debug.Log ("STOP");
			ButtoninTransit = false;
		}*/
	//}

	void FixedUpdate () {
		if (ButtonPressed == true) {
			//float distCovered = (Time.time - startTime) * speed;
			//float fracJourney = distCovered / journeyLength;
			//transform.position = Vector3.Lerp(Homepos.position, Pressedpos.position, fracJourney);
			GetComponent<Rigidbody> ().MovePosition (Pressedpos.position);
			//ButtonPressed = true;
			/*Debug.Log ("Pressed");
			RotationSpeed = -RotationSpeed;
			ButtoninTransit = true;*/
		} else {
			//float distCovered = (Time.time - startTime) * speed;
			//float fracJourney = distCovered / journeyLength;
			//transform.position = Vector3.Lerp(Pressedpos.position, Homepos.position, fracJourney);
			GetComponent<Rigidbody> ().MovePosition (Homepos.position);
			//ButtonPressed = false;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Hand") && ButtonPressed == false && Time.time > nextPress) {
			nextPress = Time.time + pressDelay;
			ButtonPressed = true;
		}
		else if (other.gameObject.CompareTag ("Hand") && ButtonPressed == true && Time.time > nextPress) {
			nextPress = Time.time + pressDelay;
			ButtonPressed = false;
		}
	}

	void OnMouseDown() {
		if (Time.time > nextPress && ButtonPressed == false) {
			nextPress = Time.time + pressDelay;
			ButtonPressed = true;
			buttonPressInstant = Time.time;
			Debug.Log (buttonPressInstant + "Time: " + Time.time);
		}
		else if (Time.time > nextPress) {
			nextPress = Time.time + pressDelay;
			ButtonPressed = false;
			buttonPressInstant = Time.time;
			Debug.Log (buttonPressInstant + "Time: " + Time.time);
		}
	}

	/*void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Hand")) {
			ButtonPressed = false;
		}
	}*/

	/*void SmoothRotate () {
		Button.transform.RotateAround (Pivot.position, Pivot.right, RotationSpeed * Time.deltaTime);
	}*/
}

using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
	
	public float verticalSensitivity = 1;
	public float horizontalSensitivity = 1;
	public bool mouseCenteredAndHidden; //[ESC] key toggles mouse
	public bool allowEscape;
	private Vector2 total;
	private Vector2 sensitivityModifier;
	private bool lockCursor;
	
	// Use this for initialization
	void Start ()
	{
		lockCursor = mouseCenteredAndHidden;
		sensitivityModifier = new Vector3 (horizontalSensitivity, verticalSensitivity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (allowEscape && Input.GetKeyDown (KeyCode.Escape))
			Screen.lockCursor = !Screen.lockCursor;//check if we should unlock cursor
		/*
		if (Screen.lockCursor != lockCursor) {
			if (lockCursor && Input.GetMouseButton (0))
				Screen.lockCursor = true;
			else if (!lockCursor)
				Screen.lockCursor = false;
		}
		*/
		total += Vector2.Scale (new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y")), sensitivityModifier); //total look vector + (delta move * sensitivity modifier);
		
		Quaternion horizontalRotation = Quaternion.AngleAxis (total.x, Vector3.up); //lateral turn;
		Quaternion verticalRotation = Quaternion.AngleAxis (Mathf.Clamp (-total.y, -90, 90), Vector3.right); //vertical turn;
		
		transform.rotation = horizontalRotation * verticalRotation; //apply, using horizontal first;
	}
}
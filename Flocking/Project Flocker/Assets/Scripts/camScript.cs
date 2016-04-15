using UnityEngine;
using System.Collections;
[AddComponentMenu("Camera-Control/Mouse Look")]

/// <summary>
/// Class for adding MouseLook to a camera or a transform with a camera attached to it.
/// This will rotate the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation
/// </summary>
/// 

public class camScript : MonoBehaviour {

    // Use this for initialization

    public float sensitivityX = 10f;
    public float sensitivityY = 10f;

    public float minimumY = -60f;
    public float maximumY = 60f;
    private Vector3 rotation;

    void Start () {

        rotation = new Vector3();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotation.y += Input.GetAxis("Mouse Y") * sensitivityY;
        rotation.y = Mathf.Clamp(rotation.y, minimumY, maximumY);

        rotation.Set(-rotation.y, rotationX, 0);
        transform.localEulerAngles = rotation;

    }
}


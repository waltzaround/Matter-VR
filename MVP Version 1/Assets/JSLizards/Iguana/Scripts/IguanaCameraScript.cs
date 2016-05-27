using UnityEngine;
using System.Collections;

public class IguanaCameraScript : MonoBehaviour {
	public GameObject target;
	public float turnSpeed=.2f;
	public GameObject IguanaCamera;
	float cameraAngleX=180f;
	float cameraAngleY=0f;
	public float cameraDistance=3f;
	
	public void Start(){
		Quaternion arotation = Quaternion.identity;
		Vector3 eua = Vector3.zero;
		eua.y = 360f-cameraAngleY;
		eua.z = 0f;
		eua.x = 180f+cameraAngleX;
		arotation.eulerAngles = eua;
		transform.localRotation= arotation;
	}
	
	void Update(){
		if (Input.GetKey (KeyCode.Mouse1)) {
			cameraAngleY+= Input.GetAxis("Mouse X");
			cameraAngleX+= Input.GetAxis("Mouse Y");
		}
		CameraRotationX ();
		CameraRotationY ();
		cameraDistance=cameraDistance+Time.deltaTime*Input.GetAxis ("Mouse ScrollWheel");
		IguanaCamera.transform.localPosition = new Vector3 (0f,cameraDistance,-2f*cameraDistance);
	}
	
	public void TargetSet(GameObject aTarget){
		target = aTarget;
	}
	
	public void CameraRotationX(){
		Quaternion arotation = Quaternion.identity;
		Vector3 eua = Vector3.zero;
		eua.y = 360f-cameraAngleY;
		eua.z = 0f;
		eua.x = 180f+cameraAngleX;
		arotation.eulerAngles = eua;
		transform.localRotation= arotation;
	}
	public void CameraRotationY(){
		Quaternion arotation = Quaternion.identity;
		Vector3 eua = Vector3.zero;
		eua.y = 360f-cameraAngleY;
		eua.z = 0f;
		eua.x = 180f+cameraAngleX;
		arotation.eulerAngles = eua;
		transform.localRotation= arotation;
	}
	void FixedUpdate(){
		transform.position = Vector3.Lerp (transform.position,target.transform.position,Time.deltaTime*10f);
	}
}

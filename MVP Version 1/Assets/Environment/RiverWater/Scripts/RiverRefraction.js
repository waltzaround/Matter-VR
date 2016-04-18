#pragma strict

var tex : Texture2D;
var fallback : Texture2D;
private var matrice : Vector2;
@range (1,8)
var quality : int = 1;
var flowspeed : float;
var renderers : Renderer[];
var refraction : boolean;

//cameras
private var WaterCam : GameObject;
var FarClipPlane : int;

function Start () {
	tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	matrice = new Vector2(0,0);

	WaterCam = new GameObject("RefractCamera");
	WaterCam.AddComponent.<Camera>();
	WaterCam.GetComponent.<Camera>().enabled = true;
	WaterCam.GetComponent.<Camera>().farClipPlane = GetComponent.<Camera>().farClipPlane;
	WaterCam.GetComponent.<Camera>().depth = GetComponent.<Camera>().depth-1;
	WaterCam.GetComponent.<Camera>().cullingMask = 1 + 0;
}

function Update () {
	matrice.x = matrice.x+(flowspeed/100);
	matrice.y = matrice.y-(flowspeed/100);
	
	for (var i = 0; i < renderers.length; ++i) {
	renderers[i].sharedMaterial.SetTextureOffset("_Normals",-matrice);
	renderers[i].sharedMaterial.SetTextureOffset("_ReflectTex",matrice);
	renderers[i].sharedMaterial.SetTextureOffset("_WaveMap",matrice);
		if (refraction){
			renderers[i].sharedMaterial.SetTexture("_RefractTex",tex);
		}
		else {
			renderers[i].sharedMaterial.SetTexture("_RefractTex",fallback);
		}
	}
}

function OnPreCull () {
	if (refraction){
		WaterCam.transform.position = transform.position;
		WaterCam.transform.rotation = transform.rotation;
		WaterCam.GetComponent.<Camera>().rect = Rect(0,0,1.0f/quality,1.0f/quality);
		WaterCam.GetComponent.<Camera>().Render();
		tex.Resize(Screen.width/quality, Screen.height/quality, TextureFormat.ARGB32, false);
		tex.ReadPixels(new Rect(0,0,Screen.width/quality,Screen.width/quality),0,0);
		tex.Apply();
		for (var i = 0; i < renderers.length; ++i) {
				renderers[i].sharedMaterial.SetTexture("_RefractTex",tex);
		}
	}
}
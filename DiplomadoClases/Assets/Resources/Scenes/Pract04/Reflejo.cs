using UnityEngine;
using System.Collections;

public class Reflejo : MonoBehaviour {
	
	public GameObject plane;
	private Material mat;

	// Use this for initialization
	void Start () {
		mat = plane.GetComponent<MeshRenderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		//mat.mainTexture = RTImage(Camera.main); 
	}
	Texture2D RTImage(Camera cam) {
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = cam.targetTexture;
		cam.Render();
		Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
		image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
		image.Apply();
		RenderTexture.active = currentRT;
		return image;
	}
}

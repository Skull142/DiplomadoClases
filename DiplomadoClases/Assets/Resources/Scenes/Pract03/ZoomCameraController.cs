using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ZoomCameraController : MonoBehaviour {

	[Range(1f,100f)]public float velocityZoom = 10f;

	private Camera vcam;
	
	void Start()
	{
		vcam = this.GetComponent<Camera> ();
	}
	void Update () {
		vcam.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * -1f * velocityZoom;
		vcam.fieldOfView = Mathf.Clamp (vcam.fieldOfView, 20f, 60f);
	}
}

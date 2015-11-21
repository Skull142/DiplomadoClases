using UnityEngine;
using System.Collections;

public class RotationByMouseController : MonoBehaviour {

	public Vector2 sensibility = new Vector2(50f, 50f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rotY = Input.GetAxis ("Mouse X") * sensibility.x * Time.deltaTime;
		float rotX = Input.GetAxis ("Mouse Y") * sensibility.y * Time.deltaTime;
		this.transform.localEulerAngles += new Vector3 ( -rotX, rotY, 0f);
	
	}
}

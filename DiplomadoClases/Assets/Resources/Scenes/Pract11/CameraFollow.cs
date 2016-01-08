using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = this.target.transform.position+(new Vector3(0f, 1f, -10f));
	}
}

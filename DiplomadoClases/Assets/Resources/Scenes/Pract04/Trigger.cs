using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
	{
		this.GetComponent<MeshRenderer> ().material.color = Color.red;
	}
	void OnTriggerExit(Collider coll)
	{
		this.GetComponent<MeshRenderer> ().material.color = Color.blue;
	}
}

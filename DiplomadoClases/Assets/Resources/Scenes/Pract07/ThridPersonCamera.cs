using UnityEngine;
using System.Collections;

public class ThridPersonCamera : MonoBehaviour {

	public float height = 10f;
	public float distance = 15f;
	public Transform target;
	public float smooth  = 5f;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = target.position + (target.up*height) + (target.forward*distance);
		this.transform.position = Vector3.Lerp (this.transform.position, targetPosition, Time.deltaTime*smooth);
		this.transform.LookAt (this.target.position);
	}
}

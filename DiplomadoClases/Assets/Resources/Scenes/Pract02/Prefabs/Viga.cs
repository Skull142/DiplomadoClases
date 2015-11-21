using UnityEngine;
using System.Collections;

public class Viga : MonoBehaviour {

	public float tiempo = 1f;
	public Vector3 direccion = Vector3.forward;

	private Vector3 posIni;

	void Start()
	{
		posIni = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float aux = LucesRot.PingPong( Time.time, direccion.z*-1f, direccion.z);
		this.transform.position = Vector3.forward * aux + posIni;
	}
}

using UnityEngine;
using System.Collections;

public class Viga : MonoBehaviour {
	
	public float tiempo = 1f;
	public Vector3 direccion = Vector3.forward*10f;
	public float duration = 10;

	private Vector3 posIni;
	private Vector3 dirInternal;

	void Start()
	{
		posIni = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		dirInternal = direccion.normalized;
		float aux = LucesRot.PingPong( Time.time * duration, direccion.z*-1f, direccion.z);
		this.transform.position = dirInternal * aux + posIni;
	}
}

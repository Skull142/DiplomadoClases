using UnityEngine;
using System.Collections;

public class Tets : MonoBehaviour {

	[HideInInspector]public float velocidad = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime * velocidad;
	}
}

using UnityEngine;
using System.Collections;

public class ManagerScene : MonoBehaviour {

	public string scene;
	void Awake()
	{
		Debug.Log ("Awake");
	}
	void Start()
	{
		Debug.Log ("Start");
	}
	void Update () 
	{
		if (Input.GetKey (KeyCode.L))
			Application.LoadLevel (scene);
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
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
			SceneManager.LoadScene(scene);
	}
}

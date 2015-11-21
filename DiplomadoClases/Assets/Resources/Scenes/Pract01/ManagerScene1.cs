using UnityEngine;
using System.Collections;

public class ManagerScene1: MonoBehaviour {

	void Awake()
	{
		Vector2 rand = new Vector2 (Random.Range (0, Application.levelCount), Random.Range (0, Application.levelCount));
		Application.LoadLevelAdditive ((int)rand.x);
		Application.LoadLevelAdditive ((int)rand.y);
		print (rand);
	}

	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
			Application.LoadLevel (0);
	}
}

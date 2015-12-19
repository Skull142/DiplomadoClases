using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ManagerScene1: MonoBehaviour {

	void Awake()
	{
		Vector2 rand = new Vector2 (Random.Range (0, SceneManager.sceneCount), Random.Range (0, SceneManager.sceneCount));
		SceneManager.MergeScenes (SceneManager.GetSceneAt((int)rand.x), SceneManager.GetActiveScene());
		SceneManager.MergeScenes (SceneManager.GetSceneAt((int)rand.y), SceneManager.GetActiveScene());
		print (rand);
	}

	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
			SceneManager.LoadScene(0);
	}
}

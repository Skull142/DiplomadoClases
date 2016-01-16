using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	public static int bananas;
	public Text labelBanas;

	void Start()
	{
		bananas = 0;
	}

	void Update()
	{
		this.labelBanas.text = "x"+bananas.ToString ();
		if( Input.GetKeyDown(KeyCode.L) )
			SceneManager.LoadScene("Pract14");
	}
}

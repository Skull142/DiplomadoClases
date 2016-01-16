using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	public static int bananas;
	public Text labelBanas;

	void Update()
	{
		this.labelBanas.text = "x"+bananas.ToString ();
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillManager : MonoBehaviour {

	public Text kills;
	public static int Kills;

	// Use this for initialization
	void Start () {
		Kills = 0;
		this.kills.text = "Kills";
	}

	void Update()
	{
		this.kills.text = "Kills: " + Kills;
	}
}

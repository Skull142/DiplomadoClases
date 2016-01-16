using UnityEngine;
using System.Collections;

public class SwitchPointEffector : MonoBehaviour 
{
	public GameObject pointEffector;
	// Use this for initialization
	void Start () 
	{
		this.pointEffector.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown(KeyCode.R) )
			this.pointEffector.SetActive (!this.pointEffector.activeSelf);
	}
}

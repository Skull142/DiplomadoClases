using UnityEngine;
using System.Collections;

public class BarrelGenerator : MonoBehaviour 
{
	public GameObject master;
	public float time2Launch = 2f;
	public bool autoDestroid = false;
	public float time2Life = 10;

	// Use this for initialization
	void Start () 
	{
		this.InvokeRepeating("LaunchBarrel", 0f, this.time2Launch);
	}
	
	public void LaunchBarrel()
	{
		if (this.autoDestroid)
			Destroy (Instantiate (this.master, this.transform.position, this.transform.rotation) as GameObject, this.time2Life);
		else
			Instantiate (this.master, this.transform.position, this.transform.rotation);
	}
}

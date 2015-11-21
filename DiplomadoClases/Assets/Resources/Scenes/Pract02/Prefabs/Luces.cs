using UnityEngine;
using System.Collections;

public class Luces : MonoBehaviour {

	public float timeChangeLight = 1;
	public float colorVel = 1;
	public float angRot = 45f ;
	public float timeChangeRot = 1;
	//
	private float counter;
	private Light _light;
	private Color colorChange;
	private Vector3 rotLight;

	// Use this for initialization
	void Start () {
		counter = Time.time + timeChangeLight;
		_light = this.GetComponent<Light> ();
		colorChange = _light.color;
		rotLight = Vector3.right * angRot;
	}
	
	// Update is called once per frame
	void Update () {
		Rotation ();
		if (Time.time >= counter) 
		{
			colorChange = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)255);
			counter += timeChangeLight;
		}
		_light.color = Color.Lerp (_light.color, colorChange, Time.deltaTime*colorVel);
	}

	void Rotation()
	{
		this.transform.eulerAngles = Vector3.Lerp ( this.transform.eulerAngles, rotLight , Time.deltaTime*timeChangeRot);
	}
}

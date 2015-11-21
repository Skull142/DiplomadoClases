using UnityEngine;
using System.Collections;

public class Luces : MonoBehaviour {

	public float timeChangeColor = 1;
	[Range(0.1f,100f)] public float durationTransitionColor = 1;
	//
	private float counter;
	private float timeColor;
	private Light _light;
	private Color colorChange;

	// Use this for initialization
	void Start () {
		counter = Time.time + timeChangeColor;
		_light = this.GetComponent<Light> ();
		colorChange = _light.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= counter) 
		{
			colorChange = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)255);
			counter += timeChangeColor;
			timeColor = Time.time;
		}
		_light.color = Color.Lerp (_light.color, colorChange, (Time.time-timeColor)/durationTransitionColor );
	}	
}

using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour {

	public float duration;
	public Vector3 endPosition;
	public float colorVel = 100f;
	public float velRotation = 10f;
	[Range(0f,1000f)] public float force = 100f;
	//
	private Vector3 startPosition;
	private float startTime;
	private Color colorMat;
	private MeshRenderer mesh;
	private Rigidbody body;
	// Use this for initialization
	void Start () {
		startTime = 10f;
		startPosition = this.transform.position;
		mesh = this.GetComponent<MeshRenderer> ();
		colorMat = mesh.material.color;
		mesh.material.color = colorMat;
		body = this.GetComponent<Rigidbody>();
		DontDestroyOnLoad (this.gameObject);
		//Destroy (this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Rotate ( Vector3.up*velRotation*Time.deltaTime, Space.World );
		if(Input.GetKeyDown(KeyCode.Space))
		{
			colorMat = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)255);
			startTime = Time.time;
		}
		mesh.material.color = Color.Lerp (mesh.material.color, colorMat, Time.deltaTime*colorVel);
		this.transform.position = Vector3.Lerp ( startPosition, endPosition , (Time.time - startTime)/ duration);
	}
}

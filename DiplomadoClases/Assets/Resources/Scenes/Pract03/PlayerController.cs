using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public Vector2 velocity = new Vector2( 10f, 10f);
	[Range(0f, 1000f)]public float force = 100f;
	public KeyCode sprintKey = KeyCode.LeftShift;
	public float sprintVelocity = 1.5f;
	public GameObject vcam;
	//
	private Rigidbody body;
	private float stepCount; 

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody> ();
		stepCount = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
		{
			bool sprint = ( Input.GetKey(sprintKey) );
			this.transform.localPosition += this.transform.forward * Time.deltaTime * velocity.x * Input.GetAxis("Vertical") * (sprint ? sprintVelocity:1);
			this.transform.localPosition += this.transform.right * Time.deltaTime * velocity.y * Input.GetAxis("Horizontal");
			vcam.transform.localPosition += Vector3.up*(Mathf.Sin( stepCount ))/25;
			stepCount = ( stepCount + ( Time.deltaTime *  (sprint ? sprintVelocity*10:velocity.y ) ) )% (Mathf.PI*2);
			print(stepCount);
		}
		if (Input.GetKeyDown (KeyCode.Space))
			body.AddForce (Vector3.up * force);
	
	}
}

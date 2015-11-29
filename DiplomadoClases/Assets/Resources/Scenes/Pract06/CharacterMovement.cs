using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[HideInInspector] public Vector3 movementVector = Vector3.one;
	public  float speed = 10f;
	public float downSpeed = -10;
	public float jumpForce = 1f;
	public float tJump = 1f;
	//
	[HideInInspector] public bool jump;
	private CharacterController character;
	private Rigidbody body;
	private float counterJump;

	void Start () 
	{
		character = this.GetComponent<CharacterController> ();
		body = this.GetComponent<Rigidbody> ();
		jump = false;
		counterJump = 0f;
	}

	void Update () 
	{
		movementVector = Vector3.zero;
		//
		if (Input.GetKeyDown (KeyCode.Space) && !jump)
			jump = true;
		//
		if(this.jump)
		{
			counterJump += Time.deltaTime;
			if(counterJump >= tJump && jump)
			{
				this.counterJump = 0f;
				this.jump = false;
			}
		}
		//
		Movement ();
		character.Move ( this.transform.right * movementVector.x );
		character.Move ( this.transform.up * movementVector.y );
		character.Move ( this.transform.forward * movementVector.z );
	}

	void Movement()
	{
		movementVector.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		movementVector.z = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		movementVector.y = jump ? jumpForce : downSpeed * Time.deltaTime;
	}

	void OnControllerColliderHit(ControllerColliderHit cch)
	{
	

	}

}

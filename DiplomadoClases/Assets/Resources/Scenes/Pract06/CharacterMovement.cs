using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[HideInInspector] public Vector3 movementVector = Vector3.one;
	public  float speed = 10f;
	public float downSpeed = -10;
	private bool jump;
	public float jumpForce = 1f;
	private CharacterController character;
	private Rigidbody body;

	void Start () 
	{
		character = this.GetComponent<CharacterController> ();
		body = this.GetComponent<Rigidbody> ();
		jump = false;
	}

	void Update () 
	{
		movementVector = Vector3.zero;
		if (!character.isGrounded) 
		{
			character.SimpleMove ((this.transform.up) * (downSpeed) * Time.deltaTime);
			if(jump)
			{

			}

		}

		if (character.isGrounded && Input.GetKeyDown (KeyCode.Space))
			jump = true;
		Movement ();
		character.Move ( this.transform.forward * movementVector.z );
		character.Move ( this.transform.right * movementVector.x );
	}

	void Movement()
	{
		movementVector.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		movementVector.z = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		movementVector.y = downSpeed * Time.deltaTime;
	}

	void OnControllerColliderHit(ControllerColliderHit cch)
	{
	

	}

}

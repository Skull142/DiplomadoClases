using UnityEngine;
using System.Collections;

public enum PlayerState
{
	ALIVE,
	DEAD
}

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerControllerAnimator : MonoBehaviour 
{
	public float forwardCollitionLenght = 1f;
	public float offsetDown  = 1f; 
	public PlayerState state;
	public LayerMask shootLayer;
	public bool climb = true;
	[HideInInspector] public Animator animator;
	[HideInInspector] public AnimatorStateInfo stateInfo;
	[HideInInspector] public CapsuleCollider capsule;
	private bool jumpUp;
	private bool jumpDown;
	private float startHeightCollider;
	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
		this.capsule = this.GetComponent<CapsuleCollider> ();
		this.animator.SetFloat("HeightCollider", this.capsule.height);
		this.state = PlayerState.ALIVE;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.state == PlayerState.DEAD)
			return;
		this.stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		animator.SetFloat("Speed", jumpDown ?  0:Input.GetAxis("Vertical"));
		animator.SetFloat("Direction", Input.GetAxis("Horizontal"));
		if(this.stateInfo.IsName("Jump"))
			this.capsule.height = this.animator.GetFloat ("HeightCollider");
		//
		if (Input.GetKeyDown (KeyCode.P))
			animator.SetTrigger ("Dead");
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (stateInfo.IsName ("LocomotionForward"))
				animator.SetTrigger ("Jump");
		} 
		if (Input.GetKeyDown (KeyCode.Q)) 
			animator.SetTrigger ("Wave");
		if (Input.GetMouseButtonDown (0)) 
		{
			animator.SetTrigger ("Shoot");
			Ray ray = new Ray (this.capsule.center + this.transform.position, this.transform.forward);
			RaycastHit hitShoot;
			if (Physics.Raycast (ray, out hitShoot, 100f)) 
			{
				if(hitShoot.transform.tag == "Enemy")
				{
					hitShoot.transform.SendMessage("Dead");
					Debug.DrawRay(ray.origin, hitShoot.point);
				}
			}
			else
				Debug.DrawRay(ray.origin, ray.direction);
		}
		//
		if (!this.climb)
			return;
		Ray rayForward= new Ray (this.capsule.center + this.transform.position, this.transform.forward);
		Ray rayDown = new Ray (this.capsule.center + this.transform.position, this.transform.up * -1f);
		RaycastHit hit;
		if (Physics.Raycast (rayForward, out hit, forwardCollitionLenght) && !jumpUp) 
		{
			animator.SetBool ("JumpUP", true);
			jumpUp = true;
		} else 
		{
			animator.SetBool ("JumpUP", false);
			jumpUp = false;
		}

		if (!Physics.Raycast (rayDown, out hit, (this.capsule.height/2) + offsetDown) && !jumpDown) 
		{
			animator.SetBool ("JumpDown", true);
			jumpDown = true;
		} else 
		{
			animator.SetBool ("JumpDown", false);
			jumpDown = false;
		}
		Debug.DrawRay(rayForward.origin, rayForward.direction);
		Debug.DrawRay(rayDown.origin, rayDown.direction);
	}

	public void Dead()
	{
		if (this.state == PlayerState.DEAD)
			return;
		this.animator.SetTrigger ("Dead");
		StartCoroutine ("Restart");
		this.state = PlayerState.DEAD;
	}

	public IEnumerator Restart()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("Pract09");
	}
}

using UnityEngine;
using System.Collections;

public class PlayerControllerAnimator : MonoBehaviour {

	public float forwardCollitionLenght = 1f;
	public float offsetDown  = 1f; 

	[HideInInspector] public Animator animator;
	[HideInInspector] public AnimatorStateInfo stateInfo;
	[HideInInspector] public CapsuleCollider capsule;
	private bool jumpUp;
	private bool jumpDown;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
		this.capsule = this.GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray rayForward= new Ray (this.capsule.center + this.transform.position, this.transform.forward);
		Ray rayDown = new Ray (this.capsule.center + this.transform.position, this.transform.up * -1f);
		RaycastHit hit;
		this.stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		animator.SetFloat("Speed", Input.GetAxis("Vertical"));
		animator.SetFloat("Direction", Input.GetAxis("Horizontal"));
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if(stateInfo.IsName("Locomotion"))
				animator.SetTrigger ("Jump");
		}
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			animator.SetTrigger ("Wave");
		}
		//
		if (Physics.Raycast (rayForward, out hit, forwardCollitionLenght) && !jumpUp) {
			animator.SetBool ("JumpUP", true);
			jumpUp = true;
		} else {
			animator.SetBool ("JumpUP", false);
			jumpUp = false;
		}

		if (!Physics.Raycast (rayDown, out hit, this.capsule.height + offsetDown) && !jumpDown) {
			animator.SetBool ("JumpDown", true);
			jumpDown = true;
		} else {
			animator.SetBool ("JumpDown", false);
			jumpDown = false;
		}
		print (jumpUp);


	}
}

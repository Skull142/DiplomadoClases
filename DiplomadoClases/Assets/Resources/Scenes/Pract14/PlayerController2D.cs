using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController2D: MonoBehaviour {
	public float speed2Walk = 1f;
	public float force = 1f;
	//
	private Animator animator;
	private AnimatorStateInfo animatorStateInfo;
	private SpriteRenderer sprite;
	private Rigidbody2D body;
	// Use this for initialization
	void Start () 
	{
		this.animator = this.GetComponent<Animator> ();
		this.sprite = this.GetComponent<SpriteRenderer> ();
		this.body = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.animatorStateInfo = animator.GetCurrentAnimatorStateInfo (0);
		float dir = Input.GetAxisRaw ("Horizontal");
		//
		if (dir < 0)		this.sprite.flipX = true;
		else if( dir > 0 )	this.sprite.flipX = false;
		//
		if (!this.animatorStateInfo.IsName ("DK-Damage")) 
		{
			this.animator.SetFloat ("Speed", Mathf.Abs (dir));
			this.body.position += new Vector2 (dir, 0f) * this.speed2Walk;
		}
		///////////////
		if( Input.GetKeyDown( KeyCode.D ) && !this.animatorStateInfo.IsName ("DK-Damage") )
		{
			this.animator.SetTrigger ("Damage");
		}
		if (Input.GetKeyDown (KeyCode.Space) && !this.animatorStateInfo.IsName ("DK-Damage") && !this.animatorStateInfo.IsName ("DK-Jump")) 
		{
			this.animator.SetTrigger ("Jump");
			this.body.AddForce (new Vector2(0f, 1f)*force);
		}
	}

	public IEnumerator LoadScene(string nameLevel)
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(nameLevel);
	}

	public void Damage()
	{
		if( !this.animatorStateInfo.IsName ("DK-Damage") )
			this.animator.SetTrigger ("Damage");
		this.StartCoroutine ("LoadScene", "Pract14");
	}
}

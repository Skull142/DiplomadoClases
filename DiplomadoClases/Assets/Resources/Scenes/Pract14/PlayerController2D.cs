using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController2D: MonoBehaviour {
	public float speed2Walk = 1f;
	public float force = 1f;
	public AudioClip jumpAudio;
	public AudioClip collectItemAudio;
	public AudioClip damageAudio;
	//
	private Animator animator;
	private AnimatorStateInfo animatorStateInfo;
	private SpriteRenderer sprite;
	private Rigidbody2D body;
	private AudioSource sounds;
	// Use this for initialization
	void Start () 
	{
		this.animator = this.GetComponent<Animator> ();
		this.sprite = this.GetComponent<SpriteRenderer> ();
		this.body = this.GetComponent<Rigidbody2D> ();
		this.sounds = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.animatorStateInfo = animator.GetCurrentAnimatorStateInfo (0);
		//#if UNITY_STANDALONE
			this.StandAlone();
		//#endif
		#if !UNITY_STANDALONE
			this.Mobile();
		#endif

	}
	public void Mobile()
	{
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches [0];
			print (touch.rawPosition);
			float dir;
			if (touch.position.x < (Screen.width / 2) && touch.phase == TouchPhase.Stationary && !this.animatorStateInfo.IsName ("DK-Damage")) 
			{
				dir = -1;
				this.SpriteDir (dir);
				this.animator.SetFloat ("Speed", -dir);
				this.body.position += new Vector2 (dir, 0f) * this.speed2Walk;
			}
			if (touch.position.x > (Screen.width / 2)  && touch.phase == TouchPhase.Stationary && !this.animatorStateInfo.IsName ("DK-Damage") ) 
			{
				dir = 1;
				this.SpriteDir (dir);
				this.animator.SetFloat ("Speed", dir);
				this.body.position += new Vector2 (dir, 0f) * this.speed2Walk;
			}
			if (touch.phase == TouchPhase.Began && !this.animatorStateInfo.IsName ("DK-Jump") && !this.animatorStateInfo.IsName ("DK-Damage"))
				this.Jump ();
		}
	}
	private void SpriteDir( float dir )
	{
		if (dir < 0)		this.sprite.flipX = true;
		else if( dir > 0 )	this.sprite.flipX = false;
	}

	public void StandAlone()
	{
		float dir = Input.GetAxisRaw ("Horizontal");
		//
		this.SpriteDir( dir );
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
			this.Jump ();
	}

	private void Jump()
	{
		this.animator.SetTrigger ("Jump");
		this.sounds.PlayOneShot (this.jumpAudio);
		this.body.AddForce (new Vector2(0f, 1f)*force);
	}

	public IEnumerator LoadScene(string nameLevel)
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(nameLevel);
	}
	public void SFX()
	{
		this.sounds.PlayOneShot (this.collectItemAudio);
	}

	public void Damage()
	{
		if( !this.animatorStateInfo.IsName ("DK-Damage") )
			this.animator.SetTrigger ("Damage");
		this.sounds.PlayOneShot (this.damageAudio);
		this.StartCoroutine ("LoadScene", "Pract15");
	}
}

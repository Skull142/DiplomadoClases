using UnityEngine;
using System.Collections;

public class Banana: MonoBehaviour {

	private Animator animator;
	private AudioSource sounds;
	// Use this for initialization
	void Start () 
	{
		this.animator = this.GetComponent<Animator> ();
		this.sounds = this.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			ScoreManager.bananas++;
			coll.transform.SendMessage ("SFX");
			Destroy (this.gameObject);
		}
	}
}

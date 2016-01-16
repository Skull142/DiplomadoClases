using UnityEngine;
using System.Collections;

public class Banana: MonoBehaviour {
	
	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		this.animator = this.GetComponent<Animator> ();

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			ScoreManager.bananas++;
			Destroy (this.gameObject);
		}
	}
}

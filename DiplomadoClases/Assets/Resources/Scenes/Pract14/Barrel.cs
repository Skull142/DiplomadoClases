using UnityEngine;
using System.Collections;

public class Barrel: MonoBehaviour {
	public GameObject effect;

	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		this.animator = this.GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			Destroy (Instantiate(this.effect, this.transform.position, this.transform.rotation) as GameObject, 0.5f);
			coll.gameObject.SendMessage ("Damage");
			Destroy (this.gameObject);
		}
	}
}

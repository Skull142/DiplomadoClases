using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public GameObject elementAttack;
	public GameObject deadEffect;
	public Transform sourceAttack;
	public float force = 5;
	public float offsetAttack = 1.5f;
	public bool attack;
	//
	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		this.attack = false;
		this.animator = this.GetComponent<Animator>();
	}
	//
	public void Attack( bool state )
	{
		if( state )
		{
			this.attack = true;
			this.StartCoroutine( "AttackCycle" );
		}
		else
		{
			this.attack = false;
			this.StopCoroutine( "AttackCycle" );
		}
	}

	public IEnumerator AttackCycle()
	{
		
		while(this.attack)
		{
			this.animator.SetTrigger("Attack");
			yield return new WaitForSeconds( this.offsetAttack );
		}
	}
	//
	public void LaunchAttack()
	{
		GameObject clone;
		clone = Instantiate(this.elementAttack, this.sourceAttack.position, this.sourceAttack.rotation) as GameObject;
		clone.GetComponent<Rigidbody2D>().AddForce(this.transform.right * this.force, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.gameObject.tag == "Player")
		{
			Destroy((Instantiate(this.deadEffect, this.transform.position, this.transform.rotation) as GameObject), 1f);
			Destroy(this.gameObject);
		}
		
	}
}

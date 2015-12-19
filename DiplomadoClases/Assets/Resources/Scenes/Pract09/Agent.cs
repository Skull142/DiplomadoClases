using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum EnemyState
{
	PATROL,
	CHASING, 
	DEAD
}

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour 
{

	[Header("Health")]
	public float health = 100f;
	public Image healthIndicator;
	[Header("Others")]
	public EnemyState state;
	public Transform target;
	public float refreshSearch = 0.15f;
	public float refreshPatrol = 5f;
	public Vector2 patrolArea = new Vector2(20f, 20f);
	//
	private NavMeshAgent agent;
	private Animator animator;
	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () 
	{
		this.startPosition = this.transform.position;
		this.agent = this.GetComponent<NavMeshAgent> ();	
		this.target = GameObject.FindGameObjectWithTag ("Player").transform;
		this.animator = this.GetComponent<Animator> ();
		this.state = EnemyState.PATROL;
		StartCoroutine ( "UpdateReference" );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.C))
			Instantiate (this.gameObject);
		if (this.state == EnemyState.DEAD)
			return;
		this.animator.SetFloat ("Speed", this.agent.speed);

		this.healthIndicator.transform.LookAt (Camera.main.transform.position);
	}

	public IEnumerator UpdateReference()
	{
		while(true)
		{
			if(this.state == EnemyState.PATROL)
			{
				this.endPosition = startPosition + new Vector3 (Random.Range (-this.patrolArea.x, this.patrolArea.x), 0, Random.Range (-this.patrolArea.y, this.patrolArea.y));
				this.agent.SetDestination (this.endPosition);
				yield return new WaitForSeconds (this.refreshPatrol);
			}
			if(this.state == EnemyState.CHASING)
			{
				this.agent.SetDestination (target.transform.position);
				yield return new WaitForSeconds(this.refreshSearch);
			}
		}
	}

	public void ChangeState(EnemyState state)
	{
		StopCoroutine ( "UpdateReference" );
		this.state = state;
		StartCoroutine ("UpdateReference");
	}

	public void TakeDamage (float damage)
	{
		this.health -= damage;
		this.healthIndicator.fillAmount = health / 100f;
		this.healthIndicator.color = Color.Lerp(Color.green, Color.red, (100-this.health)/100f);
		if (this.health <= 0) 
		{
			this.Dead ();
		}
	}

	public void Dead()
	{
		if (this.state == EnemyState.DEAD)
			return;
		KillManager.Kills++;
		this.state = EnemyState.DEAD;
		this.animator.SetTrigger ("Dead");
		StopAllCoroutines ();
		Destroy(this.gameObject, 3f);
		this.agent.Stop ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Player" && this.state != EnemyState.DEAD)
			coll.transform.SendMessage ("TakeDamage",25f);
	}
	
}

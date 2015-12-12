using UnityEngine;
using System.Collections;

public class EnemyGenerator: MonoBehaviour
{
	public bool clone = true;
	public float timeClone = 2;
	public int cloneForWave = 2; 
	public GameObject master;
	GameObject[] respawn ;
	void Start()
	{
		respawn = GameObject.FindGameObjectsWithTag ("Respawn");
		StartCoroutine ( "Clone" );
	}

	public IEnumerator Clone()
	{
		while(clone)
		{
			for(int i = 1; i < cloneForWave; i++)
			{
				Transform place = respawn [Random.Range (0, this.respawn.Length)].transform;
				Instantiate (master, place.position, place.rotation);
			}
			yield return new WaitForSeconds(timeClone);
		}

	}
}



using UnityEngine;
using System.Collections;

public class ChasingHelper : MonoBehaviour {


	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
			this.transform.parent.SendMessage ("ChangeState", EnemyState.CHASING );
	}
}

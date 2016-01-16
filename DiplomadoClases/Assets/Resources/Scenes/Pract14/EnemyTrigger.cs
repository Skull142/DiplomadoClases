using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.gameObject.tag == "Player")
			this.transform.parent.SendMessage("Attack", true);
	}
	//
	void OnTriggerExit2D(Collider2D coll)
	{
		if( coll.gameObject.tag == "Player")
			this.transform.parent.SendMessage("Attack", false);
	}
}

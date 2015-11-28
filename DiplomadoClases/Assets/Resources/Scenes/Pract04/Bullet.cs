using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject effect;
	public GameObject materDecal;
	public float offset = 0.1f;

	// Use this for initialization
	void OnCollisionEnter(Collision coll)
	{
		ContactPoint contact = coll.contacts [0];
		Destroy (Instantiate (effect,contact.point, Quaternion.identity), 1.5f);
		if (!coll.gameObject.GetComponent<Rigidbody> () && coll.gameObject.tag != "Terrain")
			coll.gameObject.AddComponent<Rigidbody> ();
		//
		GameObject decal = Instantiate (this.materDecal, contact.point, Quaternion.identity) as GameObject;
		decal.transform.SetParent(coll.gameObject.transform);
		decal.transform.up = contact.normal;
		decal.transform.position += decal.transform.up * offset;
		//
		//Debug.Log (coll.gameObject.name);
		Destroy(this.gameObject);
	}
}

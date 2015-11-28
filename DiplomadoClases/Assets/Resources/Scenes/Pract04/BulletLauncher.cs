using UnityEngine;
using System.Collections;

public class BulletLauncher: MonoBehaviour {

	public GameObject masterBullet;
	public float force = 75f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			GameObject clone = Instantiate(masterBullet,this.transform.position, this.transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * force, ForceMode.Impulse);
			Destroy(clone,10f);
		}
	
	}
}

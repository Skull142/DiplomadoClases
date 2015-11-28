using UnityEngine;
using System.Collections;

public class RayForce : MonoBehaviour {
	public float force = 50f;
	public GameObject coll;
	//
	private Ray mouseRay;
	private RaycastHit mouseHit;
	// Use this for initialization
	void Start () 
	{
		coll.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (mouseRay, out mouseHit, 2000f)) 
		{
			coll.GetComponent<MeshRenderer> ().enabled = true;
			coll.transform.position = mouseHit.point;
			coll.transform.up = mouseHit.normal;
			coll.transform.position += coll.transform.up * 0.1f;
			Debug.DrawLine(Camera.main.transform.position, mouseHit.point);
			//coll.transform.localScale = Vector3.one * 0.2f;
			if(Input.GetMouseButtonDown(0))
			{
				if( mouseHit.transform.tag == "Sphere" )
					mouseHit.rigidbody.AddForce(mouseRay.direction * force, ForceMode.Impulse);
			}
		}
		else
			coll.GetComponent<MeshRenderer> ().enabled = false;
	}
}

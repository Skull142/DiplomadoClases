using UnityEngine;
using System.Collections;

public class LucesRot : MonoBehaviour {
	
	[Range(0f,180f)] public float angRot = 45f;
	public float duration;

	void Update () {
		float ang = PingPong(Time.time,-this.angRot, angRot);
		this.transform.localEulerAngles = Vector3.forward * ang ;

	}
	public static float PingPong(float value, float min , float max)
	{
		return Mathf.PingPong(value, max-min) + min;
	}
}

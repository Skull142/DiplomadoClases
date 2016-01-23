using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {

	public static Utilities utilities;
	public Texture2D screenshot;

	private float minX, maxX, minY, maxY;
	public delegate void CaptureScreenShotCallBack();
	public CaptureScreenShotCallBack captureScreenShotCallBack;

	void Start () {
		utilities = this;
	}

	public void TakeScreenShot(float minXT, float maxXT, float minYT, float maxYT) {
		minX = minXT;
		maxX = maxXT;
		minY = minYT;
		maxY = maxYT;

		screenshot = new Texture2D ((int)(Screen.width * (maxX - minX)), (int)(Screen.height * (maxY - minY)), TextureFormat.RGB24, false);

		StartCoroutine ("CaptureScreenShot");
	}

	IEnumerator CaptureScreenShot () {
		yield return new WaitForEndOfFrame ();
		screenshot.ReadPixels (new Rect(Screen.width * minX, Screen.height * minY, Screen.width * (maxX - minX), Screen.height * (maxY - minY)),0,0,false);
		screenshot.Apply ();
		captureScreenShotCallBack ();
	}
}

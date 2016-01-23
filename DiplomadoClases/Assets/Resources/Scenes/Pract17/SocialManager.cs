using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SocialManager : MonoBehaviour {
	public Button facebookLogin;
	public Button shareScreenShot;
	public Texture2D currentScreenShot;

	// Use this for initialization
	void Start () {
	
	}

	public void LogInToFacebook () {
		FacebookManager.facebookManager.LogIn (new List<string>{"public_actions"});
	}
	
	public void ShareImageToFacebook () 
	{
		Utilities.utilities.captureScreenShotCallBack += CaptureScreenShotDone;
		Utilities.utilities.TakeScreenShot (0.2f,0.8f,0.2f,0.8f);
	}

	public void CaptureScreenShotDone () 
	{
		currentScreenShot =	Utilities.utilities.screenshot;
		Utilities.utilities.captureScreenShotCallBack -= CaptureScreenShotDone;
		FacebookManager.facebookManager.ShareImage ( currentScreenShot, "Test00.png", "Hola Mundo");
	}
}

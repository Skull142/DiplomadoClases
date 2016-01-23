using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
public class FacebookManager : MonoBehaviour 
{
	public static FacebookManager facebookManager;
	public bool initialized;
	public bool isUpAndRuning;

	#region Init
	public void StartFacebook()
	{
		if (initialized) 
		{
			FB.Init (OnInitComplete, OnHideUnity);
		}
	}
	private void OnInitComplete()
	{
		Debug.Log ("FB Init complete");
		this.initialized = true;
		if (FB.IsLoggedIn)
			this.isUpAndRuning = true;
	}
	private void OnHideUnity(bool isGameShow)
	{
		Debug.Log ("FB is game showing? "+isGameShow);
	}
	#endregion

	#region LogIn
	public void LogIn(List<string> permissions)
	{
		FB.LogInWithPublishPermissions (permissions, LoginCallback);
	}
	private void LoginCallback(ILoginResult result)
	{
		Debug.Log ("Trying to log in");
		if (result.Error != null)
			Debug.Log ("FB log in Error: " + result.Error);
		else if (FB.IsLoggedIn)
			OnLoggedIn ();
		else
			OnLoggedFail ();
	}
	private void OnLoggedIn()
	{
		Debug.Log ("Log in SUCESS");
	}
	private void OnLoggedFail()
	{
		Debug.Log ("Log in FAIL");
	}
	#endregion
	//
	#region LogOut
	public void LogOut()
	{
		FB.LogOut ();
	}
	#endregion
	//
	#region Share
	public void ShareImage(Texture2D image, string imageName, string message)
	{
		byte[] imageContent = image.EncodeToPNG();
		WWWForm www = new WWWForm ();
		www.AddBinaryData ("image", imageContent, imageName);
		www.AddField ("message", message);
		if (FB.IsLoggedIn) 
		{
			FB.API ("me/photos", HttpMethod.POST, CallbackShareImage, www);
		}
	}
	private void CallbackShareImage(IGraphResult result)
	{
		if (result.Error != null)
			Debug.Log ("FB ERROR to share image " + result.Error);
		else 
			Debug.Log ("SHARE image SUCESS");
	}
	#endregion
}

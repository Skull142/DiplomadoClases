using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public AudioMixer audioMixerMaster;
	public GameObject[] panels;
	public AudioSource musicSource;
	public float speedMusic = 0.001f;
	//
	public Slider sliderGlobalVolume;
	public Slider sliderMusicVolume;
	public Slider sliderFBXVolume;
	//
	private bool pause;

	void Start()
	{
		Time.timeScale = 1;
		this.pause = false;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			this.pause = !this.pause;
			if (pause)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
			foreach (GameObject p in this.panels)
				p.SetActive ( !p.activeSelf );
		}
		this.musicSource.pitch = Mathf.Lerp (this.musicSource.pitch, 3f, Time.deltaTime * this.speedMusic);

	}

	public static void SetVolume( AudioMixer mixer, string nameVolume, float valueVolume)
	{
		mixer.SetFloat (nameVolume, valueVolume);
	}
	//
	public void SetGlobalVolume()
	{
		SetVolume( this.audioMixerMaster, "GlobalVolume",this.sliderGlobalVolume.value);
	}
	//
	public void SetMusicVolume()
	{
		SetVolume( this.audioMixerMaster, "MusicVolume",this.sliderMusicVolume.value);
	}
	//
	public void SetFBXVolume()
	{
		SetVolume( this.audioMixerMaster, "FBXVolume",this.sliderFBXVolume.value);
	}

}

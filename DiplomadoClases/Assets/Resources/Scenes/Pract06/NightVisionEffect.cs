using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class NightVisionEffect : MonoBehaviour {

	public Shader nightVisionShader;
	public float contrast = 2f;
	public float brightness = 1f;
	public Color nightVisionColor = Color.white;
	//
	public Texture2D vignetteTexture;
	public Texture2D scanLineTexture;
	public Texture2D noiseTexture;
	//
	public float scanLineAmount;
	public Vector2 noiseSpeed = new Vector2(100f, 100f);
	public float distorsion = 0.2f;
	public float scale = 0.8f;
	//
	private float randomValue = 0.0f;
	private Material currentMaterial;
	Material material
	{
		get 
		{
			if (this.currentMaterial == null)
				this.currentMaterial = new Material (this.nightVisionShader);
			return this.currentMaterial;
		}

	}
	//
	void Start()
	{
		if (!SystemInfo.supportsImageEffects) 
		{
			this.enabled = false;
			return;
		}
		if(!this.nightVisionShader && !this.nightVisionShader.isSupported)
		{
			this.enabled = false;
		}
	}
	void Update () 
	{
		this.contrast = Mathf.Clamp (this.contrast, 0f, 4f);
		this.brightness = Mathf.Clamp (this.brightness, 0f, 2f);
		this.distorsion = Mathf.Clamp (this.distorsion, -1f, 1f);
		this.scale = Mathf.Clamp (this.scale, 0f, 3f);
		///
		this.randomValue = Random.Range (-1f, 1f);
	}
	//
	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.nightVisionShader != null) {
			this.material.SetFloat ("_Contrast", this.contrast);
			this.material.SetFloat ("_Brightness", this.brightness);
			this.material.SetFloat ("_RandomValue", this.randomValue);
			this.material.SetFloat ("_Distorsion", this.distorsion);
			this.material.SetFloat ("_Scale", this.scale);
			this.material.SetColor ("_NightVisionColor", this.nightVisionColor);
			//
			if (this.vignetteTexture)
				this.material.SetTexture ("_VignetteTex", this.vignetteTexture);
			if (this.scanLineTexture) 
			{
				this.material.SetTexture ("_ScanLineTex", this.scanLineTexture);
				this.material.SetFloat ("_ScanLineAmount", this.scanLineAmount);
			}
			if (this.noiseTexture) 
			{
				this.material.SetTexture ("_NoiseTex", this.noiseTexture);
				this.material.SetFloat ("_NoiseSpeedX", this.noiseSpeed.x);
				this.material.SetFloat ("_NoiseSpeedY", this.noiseSpeed.y);
			}
			//
			Graphics.Blit (sourceTexture, destTexture, this.currentMaterial);
		} 
		else
			Graphics.Blit (sourceTexture, destTexture);
			
	}
}

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GrayScaleEffect : MonoBehaviour 
{
	public Shader currentShader;
	[Range(0f, 1f)]	public float grayScaleAmount = 1f;
	//
	private Material currentMaterial;

	Material material
	{
		get 
		{
			if (this.currentMaterial == null)
				this.currentMaterial = new Material (this.currentShader);
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
		if(!this.currentShader && !this.currentShader.isSupported)
		{
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.grayScaleAmount = Mathf.Clamp (this.grayScaleAmount, 0f, 1f);
	}
	//
	void OnDisable()
	{
		if (this.currentMaterial)
			DestroyImmediate (this.currentMaterial);	
	}
	//ES LA BASE DE PREPROCESAMIENTO	
	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.currentShader != null) 
		{
			this.material.SetFloat ("_LuminosityAmount", this.grayScaleAmount);
			Graphics.Blit (sourceTexture, destTexture, this.material);
		}
		else
			Graphics.Blit (sourceTexture, destTexture);
	}
}

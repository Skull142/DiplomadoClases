Shader "Diplomado/Night Vision Effect" 
{
	Properties 
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_VignetteTex("Vignette Texture", 2D) = "white" {}
		//
		_ScanLineTex("ScanLine Texture", 2D) = "white" {}
		_ScanLineAmount("Scan Line Amount", float) = 4
		//
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_NoiseSpeedX("Noise Speed X", float) = 100
		_NoiseSpeedY("Noise Speed Y", float) = 100
		//
		_Contrast("Contrast", Range(0, 4)) = 2
		_Brightness("Brightness", Range(0, 2)) = 1
		_RandomValue("Random Value", float) = 0
		_Distorsion("Distorsion", float) = 0.2
		_Scale("Scale (ZOOM)", float) = 0.8
		_NightVisionColor("Night Vision Color", Color) = (1,1,1,1)
	}
	SubShader 
	{
		pass
		{
			CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#include "UnityCG.cginc"
				//
				uniform sampler2D _MainTex;
				uniform sampler2D _VignetteTex;
				//
				uniform sampler2D _ScanLineTex;
				float _ScanLineAmount;
				//
				uniform sampler2D _NoiseTex;
				fixed _NoiseSpeedX;
				fixed _NoiseSpeedY;
				//
				fixed _Contrast;
				fixed _Brightness;
				fixed _RandomValue;
				fixed _Distorsion;
				fixed _Scale;
				fixed4 _NightVisionColor;
				//
				float2 barrelDistortion(float2 coord)
				{
					float2 h = coord.xy - float2(0.5, 0.5);
					float2 r2 = h.x * h.x + h.y * h.y;
					float r = 1 + r2 * (_Distorsion * sqrt(r2));
					return r * _Scale * h + 0.5;
				}
				//
				fixed4 frag(v2f_img i) : COLOR
				{
					half2 distortedUV = barrelDistortion(i.uv);
					fixed4 renderTex = tex2D(_MainTex, distortedUV);
					fixed4 vignetteTex = tex2D(_VignetteTex, i.uv);
					//
					half2 scanLineUV = half2(i.uv.x *_ScanLineAmount, i.uv.y *_ScanLineAmount);
					fixed4 scanLineTex = tex2D(_ScanLineTex, scanLineUV);
					//
					half2 noiseUV = half2(i.uv.x + (_RandomValue * _SinTime.z * _NoiseSpeedX), i.uv.y + (_Time.x * _NoiseSpeedY));
					fixed4 noiseText = tex2D(_NoiseTex, noiseUV);
					//
					fixed lum = dot( fixed3(0.229, 0.587, 0.114), renderTex.rgb);
					lum += _Brightness;
					//
					fixed4 finalColor = (lum*2) + _NightVisionColor;
					finalColor = pow(finalColor, _Contrast);
					finalColor *= vignetteTex; 
					finalColor *= scanLineTex * noiseText;
					return finalColor;
				}
			ENDCG
		}
		
	}

}

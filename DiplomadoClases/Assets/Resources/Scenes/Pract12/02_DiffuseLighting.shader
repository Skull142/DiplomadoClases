Shader "Diplomado/Diffuse Lighting" {
	Properties 
	{
		_MainTexture("Main Texture", 2D) = "white" {}
		_RampTexture("Ramp Texture", 2D) = "white" {}
		_AmbientColor("Ambient Color", Color) = (1,1,1,1)
		_EmissiveColor("Emisive Color", Color) = (1,1,1,1)
		_PowerValue("Emisive Power", range(0, 10)) = 2.5 
	}
	SubShader 
	{
		tags { "RenderType" = "Opaque" }
		//blend DstColor Zero
		CGPROGRAM
			#pragma surface surf BasicDiffuse
			sampler2D _MainTexture;
			sampler2D _RampTexture;
			float4 _EmissiveColor;
			float _PowerValue;
			float4 _AmbientColor;
			struct  Input
			{
				float2 uv_MainTexture;
			};

			inline float4 LightingBasicDiffuse(SurfaceOutput s, fixed3 lightDir, half3 viewDir,fixed atten) //Lighting+lo que esta en pragma
			{
				float difLight = max(0, dot(s.Normal, lightDir));
				float rimLight = dot(s.Normal, viewDir);
				float hLambert = difLight * 0.5 +0.5;
				float3 ramp = tex2D(_RampTexture, float2(difLight, rimLight)).rgb;
				float4 col;
				col.rgb = s.Albedo * _LightColor0.rgb * ramp;
				col.a = s.Alpha;
				return col;
			}

			void surf(Input IN, inout SurfaceOutput o)
			{
				float4 finalColor = tex2D(_MainTexture, IN.uv_MainTexture) * pow((_EmissiveColor + _AmbientColor), _PowerValue);
				o.Albedo = finalColor.rgb;
				o.Alpha = finalColor.a;
			}
		ENDCG
	}
	FallBack "Diffuse"
}

Shader "Diplomado/Basic Normal" {
	Properties 
	{
		_MainTexture("Main Texture", 2D) = "white" {}
		_NormalTexture("Normal Texture", 2D) = "white" {}
		_EmissiveTexture("Emessive Texture", 2D) = "white" {}
		_EmissiveColor("Emissive Color", Color) = (1,1,1,1) 
	}
	SubShader 
	{
		tags { "RenderType" = "Opaque" }
		//blend DstColor Zero
		CGPROGRAM
			#pragma surface surf Lambert
			sampler2D _MainTexture;
			sampler2D _NormalTexture;
			sampler2D _EmissiveTexture;
			float4 _EmissiveColor;
			struct  Input
			{
				float2 uv_MainTexture;
				float2 uv_NormalTexture;
			};
			void surf(Input IN, inout SurfaceOutput o)
			{
				half4 finalColor = tex2D(_MainTexture, IN.uv_MainTexture);
				o.Albedo = finalColor.rgb;
				o.Alpha = finalColor.a;
				//
				float3 normalMap = UnpackNormal(tex2D(_NormalTexture, IN.uv_NormalTexture));
				o.Normal = normalMap;
				//(
				float3 emissive = tex2D(_EmissiveTexture, IN.uv_MainTexture) * _EmissiveColor.rgb;
				o.Emission = emissive;
			}
		ENDCG
	}
	FallBack "Diffuse"
}

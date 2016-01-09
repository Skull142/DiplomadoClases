Shader "Diplomado/Basic Lighting" 
{
	Properties 
	{
		_MainTexture("Base Texture", 2D) = "white" {}	
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader 
	{
		Tags
		{ 
			"RenderType" = "Opaque"
		}
		CGPROGRAM	//bloque de codigo en lenguaje CG
			//indicar los tipos de shader a programar
			#pragma	surface surf Lambert	// tipo de shader _nombreFuncion Lamber = solo una fuente de iluminacion y la normal de la superficie
			sampler2D _MainTexture;			//es equivalente a una textura2D, y seguido de la textura que se esta enviando 
			half4 _Color;
			struct Input
			{
				float2 uv_MainTexture;
			};
			void surf(Input IN, inout SurfaceOutput o)
			{
				half4 finalColor = tex2D(_MainTexture, IN.uv_MainTexture) * _Color;
				o.Albedo = finalColor.rgb;
				o.Alpha =  finalColor.a;
			}

				
		ENDCG		//fin de bloque de codigo en lenguaje CG
	}
	FallBack "Diffuse"
}

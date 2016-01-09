Shader "Diplomado/Simple Vertex-Fragment" {
	Properties {
		_MainColor ("MainColor", Color) = (1,1,1,1)
	}
	SubShader 
	{
		//
		pass
		{		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//
			fixed4 _MainColor;
			//
			float4 vert(float4 vertex:POSITION) : SV_POSITION
			{
				return mul(UNITY_MATRIX_MVP, vertex); // MVP: MODEL VIEW PROJECTION
			}
			//
			fixed4 frag() : SV_TARGET
			{
				return _MainColor;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}

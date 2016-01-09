Shader "Diplomado/Normals" {
	SubShader 
	{
		pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				//
				struct appdata
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};
				struct v2f
				{
					float4 position : SV_POSITION;
					fixed4 color : COLOR;
				};
				//
				v2f vert(appdata v)
				{
					v2f o;
					o.position = mul(UNITY_MATRIX_MVP, v.vertex);
					o.color.rgb = v.normal * 0.5 + 0.5;
					o.color.a = 1;
					return o;
				}
				//
				fixed4 frag(v2f f): COLOR
				{
					return f.color;
				}

			ENDCG
		}
	}
	FallBack "Diffuse"
}

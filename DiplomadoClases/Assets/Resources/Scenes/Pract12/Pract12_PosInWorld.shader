Shader "Diplomado/Pract" 
{
	Properties 
	{
		_PositiveColor("Positive Color", Color) = (1,1,1,1) 
		_NegativeColor("Negative Color", Color) = (1,1,1,1) 
	}
	SubShader 
	{
		pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				//
				fixed4 _PositiveColor;
				fixed4 _NegativeColor;
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
					float4 positionAUX = mul(_Object2World, v.vertex);
					o.color = positionAUX.y > 0 ? (_PositiveColor) : ( positionAUX.y < 0 ? (_NegativeColor) : (_PositiveColor * _NegativeColor) );
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

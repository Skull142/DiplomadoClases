Shader "Diplomado/Gray Scale Effect" 
{
	Properties 
	{
		_MainTex("Render Texture", 2D) = "white" {}
		_LuminosityAmount("Luminosity Amount", Range(0, 1)) = 1
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
				fixed _LuminosityAmount;
				//
				fixed4 frag(v2f_img i) : COLOR //el parametro ya existe en el include
				{
					fixed4 renderTex =  tex2D(_MainTex, i.uv);
					float luminosity = 0.299 * renderTex.r + 0.587 * renderTex.g + 0.114 * renderTex.b;
					fixed4 finalColor = lerp(renderTex, luminosity, _LuminosityAmount);
					return finalColor;
				}
			ENDCG
		}
	}
}

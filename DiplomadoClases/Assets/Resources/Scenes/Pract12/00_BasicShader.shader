Shader "Diplomado/BasicMaterial" //solo es el ID del shader, no importa que se llame diferente al file 
{
	//ELEMENTO 01, NO OBLIGATORIO
	Properties
	{
		//nombreVar("nombreAMostar", tipoDato) = inicializacion {} *llaves solo para texturas 2D*
		_MainTexture("Base Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}
	//ELEMENTO 02, OBLIGATORIO
	SubShader
	{
		Tags 
		{ 
			"RenderType" = "Opaque" // tipo de render para objetos solidos
		}
		Pass
		{
			Material
			{
				Diffuse[_Color] 
			}
			Lighting On
			SetTexture[_MainTexture]
			{
				combine previous * texture // multiplica la textura por el color asignado en MATERIAL/DIFFUSE
			}
		}
	}
	//ELEMENTO 03, NO OBLIGATORIO
	//si no se cuenta con tarjeta de video, unity va a tratar de dar el siguiente efecto
	Fallback "Diffuse"
}
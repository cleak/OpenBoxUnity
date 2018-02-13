Shader "Voxel/PointQuadsTransparent"
{
	Properties
	{
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100

		//##############################################################//
		//                     Forward base pass
		//##############################################################//
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }

			ZWrite Off Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag_surf
			#pragma geometry geom

			#pragma multi_compile_fwdbase  nolightmap nodirlightmap nodynlightmap 

			#include "PointQuadsForwardBase.cginc"

			ENDCG
		} // End forward base pass

		//##############################################################//
		//                     Forward add pass
		//##############################################################//
		Pass
		{
			Tags{ "LightMode" = "ForwardAdd" }
			ZWrite Off Blend One One

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag_surf
			#pragma geometry geom
			#pragma multi_compile_fwdadd nolightmap nodirlightmap nodynlightmap 

			#include "PointQuadsForwardAdd.cginc"

			ENDCG
		} // End forward add pass

		//##############################################################//
		//                     Shadow caster pass
		//##############################################################//
		Pass
		{
			Tags{ "LightMode" = "ShadowCaster" }

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma geometry geom
			#pragma multi_compile_shadowcaster
			#include "UnityCG.cginc"

			#include "PointQuadsShadowCaster.cginc"
	
			ENDCG
		} // End pass ShadowCaster
	} // End subshader
} // End shader

Shader "Voxel/PointQuads"
{
	Properties
	{
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		//Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100

		//##############################################################//
		//                     Forward base pass
		//##############################################################//
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }

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
		//                     Deferred pass
		//##############################################################//
		Pass
		{
			Name "DEFERRED"
			Tags{ "LightMode" = "Deferred" }

			CGPROGRAM
			
			#pragma require geometry

			#pragma vertex vert
			#pragma fragment frag_surf
			#pragma geometry geom
			#pragma multi_compile_instancing
			#pragma target 3.0
			#pragma exclude_renderers nomrt
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#pragma multi_compile_prepassfinal noshadowmask nodynlightmap nolightmap noshadow 
		
			#include "UnityCG.cginc"
			#include "PointQuadsDeferred.cginc"
	
			ENDCG
		} // End pass ShadowCaster

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

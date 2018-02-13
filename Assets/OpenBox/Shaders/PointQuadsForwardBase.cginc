#ifndef _OPENBOX_POINTQUADFORWARDBASE_INCLUDED
#define _OPENBOX_POINTQUADFORWARDBASE_INCLUDED

#include "UnityCG.cginc"
#include "Lighting.cginc"
#include "AutoLight.cginc"
#include "UnityPBSLighting.cginc"
#include "PointQuadsHelper.cginc"

struct g2f {
	float4 pos : SV_POSITION;
	float3 worldPos : TEXTURE0;
	float4 color : COLOR0;
	fixed3 diff : COLOR1;
	fixed3 ambient : COLOR2;
	fixed3 objNormal : NORMAL0;
	fixed3 worldNormal : NORMAL1;
	SHADOW_COORDS(0)
	UNITY_FOG_COORDS(1)
};

v2g vert(appdata v) {
	return ob_MakeV2G(v);
}

[maxvertexcount(4)]
void geom(point v2g vIn[1], inout TriangleStream<g2f> vOutStream) {

	int faceIdx = (int)vIn[0].uv.x;

	float3 dx = ob_DxForFace(faceIdx);
	float3 dy = ob_DyForFace(faceIdx);
	float3 normal = ob_NormalForFace(faceIdx);

	half3 worldNormal = UnityObjectToWorldNormal(normal);

	for (int i = 0; i < 4; ++i) {
		g2f o = (g2f)0;
		o.pos = ob_GetClipPosition(vIn[0].pos.xyz, dx, dy, i);
		o.worldPos = ob_GetWorldPosition(vIn[0].pos.xyz, dx, dy, i);
		o.color = vIn[0].color;
		o.worldNormal = worldNormal;
		o.objNormal = normal;

		// Fog data
		UNITY_TRANSFER_FOG(o, o.vertex);

		// Lighting data
		half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
		o.diff = nl * _LightColor0.rgb;
		o.ambient = ShadeSH9(half4(worldNormal, 1));

		// compute shadows data
		TRANSFER_SHADOW(o);
		vOutStream.Append(o);
	}
}

fixed4 frag_surf(g2f i) : SV_Target{
#	ifdef FOG_COMBINED_WITH_TSPACE
		UNITY_EXTRACT_FOG_FROM_TSPACE(IN);
#	elif defined (FOG_COMBINED_WITH_WORLD_POS)
		UNITY_EXTRACT_FOG_FROM_WORLD_POS(IN);
#	else
		UNITY_EXTRACT_FOG(IN);
#	endif

	///UNITY_INITIALIZE_OUTPUT(Input,surfIN);
	///surfIN.uv_MainTex.x = 1.0;
	///surfIN.uv_MainTex = IN.pack0.xy;
	float3 worldPos = i.worldPos.xyz;
#	ifndef USING_DIRECTIONAL_LIGHT
		fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
#	else
		fixed3 lightDir = _WorldSpaceLightPos0.xyz;
#	endif

	fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));

#	ifdef UNITY_COMPILER_HLSL
		SurfaceOutputStandard o = (SurfaceOutputStandard)0;
#	else
		SurfaceOutputStandard o;
#	endif

	o.Albedo = i.color;
	o.Emission = 0.0;
	o.Alpha = i.color.a;
	o.Occlusion = 1.0;
	o.Smoothness = 0.5;
	fixed3 normalWorldVertex = fixed3(0,0,1);
	o.Normal = i.worldNormal;
	normalWorldVertex = i.worldNormal;

	// call surface function
	///surf(surfIN, o);

	// compute lighting & shadowing factor
	UNITY_LIGHT_ATTENUATION(atten, i, worldPos)
	fixed4 c = 0;

	// Setup lighting environment
	UnityGI gi;
	UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
	////////////gi.indirect.diffuse = 0;
	////////////gi.indirect.specular = 0;

	gi.indirect.diffuse = 0;
	gi.indirect.specular = 0;

	gi.light.color = _LightColor0.rgb;
	gi.light.dir = lightDir;
	// Call GI (lightmaps/SH/reflections) lighting function
	UnityGIInput giInput;
	UNITY_INITIALIZE_OUTPUT(UnityGIInput, giInput);
	giInput.light = gi.light;
	giInput.worldPos = worldPos;
	giInput.worldViewDir = worldViewDir;
	giInput.atten = atten;

#	if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
		giInput.lightmapUV = IN.lmap;
#	else
		giInput.lightmapUV = 0.0;
#	endif

#	if UNITY_SHOULD_SAMPLE_SH && !UNITY_SAMPLE_FULL_SH_PER_PIXEL
		//giInput.ambient = i.ambient;
		giInput.ambient = i.ambient;
#	else
		giInput.ambient.rgb = 0.0;
#	endif

	giInput.probeHDR[0] = unity_SpecCube0_HDR;
	giInput.probeHDR[1] = unity_SpecCube1_HDR;

#	if defined(UNITY_SPECCUBE_BLENDING) || defined(UNITY_SPECCUBE_BOX_PROJECTION)
		giInput.boxMin[0] = unity_SpecCube0_BoxMin; // .w holds lerp value for blending
#	endif

#	ifdef UNITY_SPECCUBE_BOX_PROJECTION
		giInput.boxMax[0] = unity_SpecCube0_BoxMax;
		giInput.probePosition[0] = unity_SpecCube0_ProbePosition;
		giInput.boxMax[1] = unity_SpecCube1_BoxMax;
		giInput.boxMin[1] = unity_SpecCube1_BoxMin;
		giInput.probePosition[1] = unity_SpecCube1_ProbePosition;
#	endif

	LightingStandard_GI(o, giInput, gi);

	// realtime lighting: call lighting function
	c += LightingStandard(o, worldViewDir, gi);
	UNITY_APPLY_FOG(_unity_fogCoord, c); // apply fog
	//UNITY_OPAQUE_ALPHA(c.a);

	//c.a = i.color.a;
	//c.a = 0.5f;

	return c;
}

#endif
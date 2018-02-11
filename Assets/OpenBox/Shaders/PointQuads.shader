Shader "Voxel/PointQuads"
{
	Properties
	{
		//_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		Pass
	{

		Tags{ "LightMode" = "ForwardBase" "LightMode" = "ForwardAdd" }
		//Tags{ "LightMode" = "ForwardBase" }
		//Tags{ "LightMode" = "ForwardAdd" }
		//Tags{ "LightMode" = "Deferred" }
		CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#pragma geometry geom
		// make fog work
		///////////////////#pragma multi_compile_fog

#include "UnityCG.cginc"
#include "Lighting.cginc"

		// compile shader into multiple variants, with and without shadows
		// (we don't care about any lightmaps yet, so skip these variants)
		//#pragma multi_compile_fwdbase  nolightmap nodirlightmap nodynlightmap novertexlight
		//#pragma multi_compile_fwdadd 
		#pragma multi_compile_fwdbase  nolightmap nodirlightmap nodynlightmap 
		// shadow helper functions and macros
#include "AutoLight.cginc"

#ifdef UNITY_PASS_FORWARDADD
		Blend One One
#endif

		struct appdata {
		float4 pos : POSITION;
		float4 color : COLOR;
		float2 uv : TEXCOORD0;
	};

	struct v2g {
		float4 pos : POSITION;
		float4 color : COLOR;
		float2 uv : TEXCOORD0;
	};

	struct g2f {
		float4 pos : SV_POSITION;
		float4 color : COLOR0;
		fixed3 diff : COLOR1;
		fixed3 ambient : COLOR2;
		SHADOW_COORDS(0)
			UNITY_FOG_COORDS(1)
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;

	v2g vert(appdata v) {
		v2g o;
		o.pos = v.pos;
		o.uv = v.uv;
		o.color = v.color;
		return o;
	}

	[maxvertexcount(4)]
	void geom(point v2g vIn[1], inout TriangleStream<g2f> vOutStream) {
		//v2g v = vIn[0];
		static const float3 offsets[4] = {
			float3(0, 0, 0),
			float3(1, 0, 0),
			float3(0, 1, 0),

			float3(1, 1, 0),
		};

		const float3 dxs[6] = {
			float3(0, 1, 0),
			float3(0, 0, 1),
			float3(0, 0, 1),
			float3(1, 0, 0),
			float3(1, 0, 0),
			float3(0, 1, 0)
		};

		const float3 dys[6] = {
			float3(0, 0, 1),
			float3(0, 1, 0),
			float3(1, 0, 0),
			float3(0, 0, 1),
			float3(0, 1, 0),
			float3(1, 0, 0)
		};

		const float3 normals[6] = {
			float3(1, 0, 0),
			float3(-1, 0, 0),

			float3(0, 1, 0),
			float3(0, -1, 0),

			float3(0, 0, 1),
			float3(0, 0, -1)
		};

		int faceIdx = (int)vIn[0].uv.x;

		float3 dx = dxs[faceIdx];
		float3 dy = dys[faceIdx];
		float3 normal = normals[faceIdx];
		half3 worldNormal = UnityObjectToWorldNormal(normal);

		//half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
		//fixed4 diff = nl * _LightColor0;
		//diff.rgb += ShadeSH9(half4(worldNormal, 1));

		for (int i = 0; i < 4; ++i) {
			g2f o = (g2f)0;
			//o.vertex = UnityObjectToClipPos(v.vertex + offsets[i]);
			o.pos = UnityObjectToClipPos(float4(vIn[0].pos.xyz
												+ offsets[i].x * dx
												+ offsets[i].y * dy,
												1));
			//o.color = vIn[0].color * diff;
			o.color = vIn[0].color;

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

	fixed4 frag(g2f i) : SV_Target
	{
		fixed4 col = i.color;
	// compute shadow attenuation (1.0 = fully lit, 0.0 = fully shadowed)
		fixed shadow = SHADOW_ATTENUATION(i);
		// darken light's illumination with shadow, keep ambient intact
		fixed3 lighting = i.diff * shadow + i.ambient;
		col.rgb *= lighting;
		//col.a = 1;
		//col.rgb = float3(shadow, shadow, shadow);
#ifdef UNITY_PASS_FORWARDADD
		//return fixed4(0);
		//return col;
#endif


#ifdef UNITY_PASS_FORWARDBASE
		return col;
		//return fixed4(0, 0, 0, 1);
#endif

		return fixed4(1, 0, 0, 1);
		//return col;

	}

		ENDCG
	}

		////////////////////////////////////////////////////////////////
		// Shadow caster pass
		////////////////////////////////////////////////////////////////

		// shadow caster rendering pass, implemented manually
		// using macros from UnityCG.cginc
		Pass
	{
		Tags{ "LightMode" = "ShadowCaster" }

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma geometry geom
#pragma multi_compile_shadowcaster
#include "UnityCG.cginc"

		/////////////////////////
		struct appdata {
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2g {
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct TempV {
		float4 vertex;
		float3 normal;
	};

	struct g2f {
		V2F_SHADOW_CASTER;
	};

	v2g vert(appdata v) {
		v2g o;
		o.vertex = v.vertex;
		o.uv = v.uv;
		return o;
	}

	[maxvertexcount(4)]
	void geom(point v2g vIn[1], inout TriangleStream<g2f> vOutStream) {
		v2g v = vIn[0];
		static const float3 offsets[4] = {
			float3(0, 0, 0),
			float3(1, 0, 0),
			float3(0, 1, 0),
			float3(1, 1, 0),
		};

		/*static const float3 offsets[4] = {
		float3(-0.1, -0.1, 0),
		float3( 1.1, -0.1, 0),
		float3(-0.1,  1.1, 0),
		float3( 1.1,  1.1, 0),
		};*/

		/*static const float3 offsets[4] = {
		float3( 0.1,  0.1, 0),
		float3( 0.9,  0.1, 0),
		float3( 0.1,  0.9, 0),
		float3( 0.9,  0.9, 0),
		};*/

		static const float3 dxs[6] = {
			float3(0, 1, 0),
			float3(0, 0, 1),
			float3(0, 0, 1),
			float3(1, 0, 0),
			float3(1, 0, 0),
			float3(0, 1, 0)
		};

		static const float3 dys[6] = {
			float3(0, 0, 1),
			float3(0, 1, 0),
			float3(1, 0, 0),
			float3(0, 0, 1),
			float3(0, 1, 0),
			float3(1, 0, 0)
		};

		static const float3 normals[6] = {
			float3(1, 0, 0),
			float3(-1, 0, 0),

			float3(0, 1, 0),
			float3(0, -1, 0),

			float3(0, 0, 1),
			float3(0, 0, -1)
		};

		/*static const float3 normals[6] = {
		float3(0.1, 0.1, 0.1),
		float3(-0.1, 0.1, 0.1),

		float3(0.1, 0.1, 0.1),
		float3(0.1, -0.1, 0.1),

		float3(0.1, 0.1, 0.1),
		float3(0.1, 0.1, -0.1)
		};*/

		int faceIdx = (int)v.uv.x;

		float3 dx = dxs[faceIdx];
		float3 dy = dys[faceIdx];
		float3 normal = normals[faceIdx];

		for (int i = 0; i < 4; ++i) {
			g2f o = (g2f)0;

			TempV v;
			v.vertex = vIn[0].vertex;
			v.normal = normal;
			v.vertex.xyz += offsets[i].x * dx;
			v.vertex.xyz += offsets[i].y * dy;

			//TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
			TRANSFER_SHADOW_CASTER(o)
				vOutStream.Append(o);
		}
	}

	float4 frag(g2f i) : SV_Target
	{
		SHADOW_CASTER_FRAGMENT(i)
	}

		ENDCG
	}
	}
}

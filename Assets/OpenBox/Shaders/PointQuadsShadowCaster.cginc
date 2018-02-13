#ifndef _OPENBOX_POINTQUADSHADOWCASTER_INCLUDED
#define _OPENBOX_POINTQUADSHADOWCASTER_INCLUDED

#include "PointQuadsHelper.cginc"

struct TempV {
	float4 vertex;
	float3 normal;
};

struct g2f {
	V2F_SHADOW_CASTER;
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

	for (int i = 0; i < 4; ++i) {
		g2f o = (g2f)0;

		TempV v;
		v.vertex = float4(ob_GetObjPosition(vIn[0].pos.xyz, dx, dy, i), 1);
		v.normal = normal;

		//TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
		TRANSFER_SHADOW_CASTER(o)

		vOutStream.Append(o);
	}
}

float4 frag(g2f i) : SV_Target
{
	SHADOW_CASTER_FRAGMENT(i)
}

#endif
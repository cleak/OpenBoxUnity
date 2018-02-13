#ifndef OPENBOX_POINTQUADSHELPER_INCLUDED
#define OPENBOX_POINTQUADSHELPER_INCLUDED

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

v2g ob_MakeV2G(appdata v) {
	v2g o;
	o.pos = v.pos;
	o.uv = v.uv;
	o.color = v.color;
	return o;
}

float3 ob_NormalForFace(int faceIdx) {
	static const float3 normals[6] = {
		float3( 1,  0,  0),
		float3(-1,  0,  0),
		float3( 0,  1,  0),
		float3( 0, -1,  0),
		float3( 0,  0,  1),
		float3( 0,  0, -1)
	};

	return normals[faceIdx];
}

float3 ob_DxForFace(int faceIdx) {
	static const float3 dxs[6] = {
		float3(0, 1, 0),
		float3(0, 0, 1),
		float3(0, 0, 1),
		float3(1, 0, 0),
		float3(1, 0, 0),
		float3(0, 1, 0)
	};

	return dxs[faceIdx];
}

float3 ob_DyForFace(int faceIdx) {
	static const float3 dys[6] = {
		float3(0, 0, 1),
		float3(0, 1, 0),
		float3(1, 0, 0),
		float3(0, 0, 1),
		float3(0, 1, 0),
		float3(1, 0, 0)
	};

	return dys[faceIdx];
}

float2 ob_GetOffset(int vIdx) {
	static const float2 offsets[4] = {
		float2(0, 0),
		float2(1, 0),
		float2(0, 1),
		float2(1, 1),
	};

	return offsets[vIdx];
}

float3 ob_GetObjPosition(float3 basePos, float3 dx, float3 dy, int vIdx) {
	float2 offset = ob_GetOffset(vIdx);
	return basePos.xyz + offset.x * dx + offset.y * dy;
}

float4 ob_GetClipPosition(float3 basePos, float3 dx, float3 dy, int vIdx) {
	float3 objPos = ob_GetObjPosition(basePos, dx, dy, vIdx);
	return UnityObjectToClipPos(float4(objPos, 1));
}

float4 ob_GetWorldPosition(float3 basePos, float3 dx, float3 dy, int vIdx) {
	float3 objPos = ob_GetObjPosition(basePos, dx, dy, vIdx);
	return mul(unity_ObjectToWorld, float4(objPos, 1));
}

#if defined(UNITY_PASS_FORWARDADD) || defined(UNITY_PASS_FORWARDBASE)
// Assumes worldNormal is already normalized
float3 ob_PerPixelLight(float3 worldPos, float3 worldNormal)
{
	float _Shininess = 1.0;

	//float3 normalDirection = normalize(input.normalDir);
	float3 viewDirection = normalize(_WorldSpaceCameraPos - worldPos);
	float3 lightDirection;
	float attenuation;

	if (0.0 == _WorldSpaceLightPos0.w) {
		// directional light
		attenuation = 1.0; // no attenuation
		lightDirection =
			normalize(_WorldSpaceLightPos0.xyz);
	} else {
		// point or spot light
		float3 vertexToLightSource =
			_WorldSpaceLightPos0.xyz - worldPos;
		float distance = length(vertexToLightSource);
		attenuation = 1.0 / distance; // linear attenuation 
		lightDirection = normalize(vertexToLightSource);
	}
	
	//float3 diffuseReflection = float3(0, 0, 0);

	float3 diffuseReflection =
		attenuation * _LightColor0.rgb * max(0.0, dot(worldNormal, lightDirection));

	float3 specularReflection;
	if (dot(worldNormal, lightDirection) < 0.0) {
		// light source on the wrong side
		specularReflection = float3(0.0, 0.0, 0.0);
		// no specular reflection
	} else {
		// light source on the right side 
		specularReflection = attenuation * _LightColor0.rgb
			* _SpecColor.rgb * pow(max(0.0, dot(
				reflect(-lightDirection, worldNormal),
				viewDirection)), _Shininess);
	}

	return diffuseReflection + specularReflection;

	//return float3(0, 0, 0);
}
#endif

#endif
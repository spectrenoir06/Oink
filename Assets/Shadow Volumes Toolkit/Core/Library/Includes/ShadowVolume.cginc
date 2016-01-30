// Upgrade NOTE: unity_Scale shader variable was removed; replaced 'unity_Scale.w' with '1.0'

// Shadow Volumes Toolkit
// Copyright 2012 Gustav Olsson
#include "UnityCG.cginc"

float4 _shadowVolumeSource;
float _shadowVolumeExtrudeBias;
float _shadowVolumeExtrudeAmount;

struct VertexInput
{
	float4 vertex : SV_POSITION;
	float3 normal : NORMAL;
};

struct VertexOutput
{
	float4 position : SV_POSITION;
};

VertexOutput ShadowVolumeVertex(VertexInput input)
{
	VertexOutput output;
	
	float3 localSource = mul(_World2Object, _shadowVolumeSource).xyz * 1.0;
	
	float3 sourceDirection = normalize(localSource - input.vertex.xyz * _shadowVolumeSource.w);
	
	float movement = _shadowVolumeExtrudeBias + _shadowVolumeExtrudeAmount * (dot(input.normal, sourceDirection) < 0.0f);
	
	output.position = mul(UNITY_MATRIX_MVP, float4(input.vertex.xyz + sourceDirection * -movement, 1.0f));
	
	return output;
}

float4 ShadowVolumeFragment() : COLOR
{
	return float4(1.0f, 1.0f, 1.0f, 2.0f / 255.0f);
}
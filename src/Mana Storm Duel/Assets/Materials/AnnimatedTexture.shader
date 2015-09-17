Shader "Custom/NewShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_RotationSpeed("Rotation Speed", Float) = 2.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _RotationSpeed;

		void vert(inout appdata_full v) {
			float sinX = sin(_RotationSpeed * _Time);
			float cosX = cos(_RotationSpeed * _Time);
			float sinY = sin(_RotationSpeed * _Time);
			float2x2 rotationMatrix = float2x2(cosX, -sinX, sinY, cosX);
			v.texcoord.xy = mul(v.texcoord.xy, rotationMatrix);
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}

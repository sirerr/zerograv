Shader "Custom/ShieldWall" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_BumpMap("Bumpmap", 2D) = "bump" {}
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Emission("Emission", Range(0,10)) = 0.0
		_Alpha ("Alpha", Range(0,1)) = 1.0
	}
	SubShader {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		half _Emission;
		half _Alpha;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			half fade = 1.0 - dot(normalize(IN.viewDir), o.Normal);

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;

			o.Emission = tex2D(_MainTex, IN.uv_MainTex) * _Color * _Emission * fade;

			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap);)

			

			o.Alpha = tex2D(_MainTex, IN.uv_MainTex).r * fade * _Alpha;
		}
		ENDCG
	}
	FallBack "Diffuse"
}

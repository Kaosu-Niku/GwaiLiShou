Shader "Bryan/UI/ColorAdjustments"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		[HDR] _Color1 ("Color", Color) = (1, 1, 1, 1)
		_Hue ("Hue", Range(-180, 180)) = 1
		_Saturation ("Saturation", Range(0, 10)) = 1
	}
	
	SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"IgnoreProjector" = "True"
			"DisableBatching" = "True"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Offset -1, -1

			HLSLPROGRAM

			#pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag
			
			#pragma shader_feature _COLOR_ADJUSTMENTS_ON
			#pragma shader_feature _COLOR_GRAYSCALE_ON

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Assets/Resources/Shaders/Bryan/ShaderLibrary/ColorAdjustments.hlsl"
	
			struct Attributes
			{
				half4 color       : COLOR;
				float4 positionOS : POSITION;
				half2 uv          : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
	
			struct Varyings
			{
				half4 color     : COLOR;
				float4 vertex   : SV_POSITION;
				half2 uv        : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			
			CBUFFER_START(UnityPerMaterial)
			TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            half4 _MainTex_ST;
			half4 _Color1;
			half  _Hue;
			half  _Saturation;
			CBUFFER_END

			Varyings vert (Attributes input)
			{
                Varyings output = (Varyings)0;
				UNITY_SETUP_INSTANCE_ID(input);
                UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
				VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
				output.color = input.color;
                output.vertex = vertexInput.positionCS;
				output.uv = TRANSFORM_TEX(input.uv, _MainTex);
				return output;
			}
			
			half4 frag (Varyings input) : SV_Target
			{
				half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv) * input.color;

#ifdef _COLOR_ADJUSTMENTS_ON
				col.rgb = ColorAdjustments(col.rgb, _Color1.rgb, _Hue, _Saturation);
#endif

#ifdef _COLOR_GRAYSCALE_ON
				col.rgb = Grayscale(col.rgb);
#endif

				return col;
			}
			ENDHLSL
		}
	}

	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"DisableBatching" = "True"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMaterial AmbientAndDiffuse
			Offset -1, -1
			Fog
			{
				Mode Off
			}
			
			SetTexture [_MainTex]
			{
				Combine Texture * Primary
			}
		}
	}

	CustomEditor "FFTech.ShaderEditor.NGUICustomShaderGUI"
}
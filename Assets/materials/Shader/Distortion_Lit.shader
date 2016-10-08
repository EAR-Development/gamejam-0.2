// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:31595,y:32713,varname:node_2865,prsc:2|diff-5646-RGB,spec-358-OUT,gloss-1813-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32037,y:32763,varname:node_6343,prsc:2|B-4982-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32274,y:33012,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e08c295755c0885479ad19f518286ff2,ntxv:3,isnm:True|UVIN-400-UVOUT;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_TexCoord,id:7358,x:31435,y:32083,varname:node_7358,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:4636,x:32356,y:32470,varname:node_4636,prsc:2|A-4549-OUT,B-206-OUT,T-6343-OUT;n:type:ShaderForge.SFN_Slider,id:4982,x:31551,y:32945,ptovrint:False,ptlb:node_4982,ptin:_node_4982,varname:node_4982,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7219598,max:1;n:type:ShaderForge.SFN_DepthBlend,id:206,x:32193,y:32528,varname:node_206,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:4549,x:32077,y:32283,varname:node_4549,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7358-UVOUT;n:type:ShaderForge.SFN_Vector3,id:2264,x:31900,y:33039,varname:node_2264,prsc:2,v1:50,v2:20,v3:100;n:type:ShaderForge.SFN_Tex2d,id:9043,x:31996,y:33197,ptovrint:False,ptlb:node_9043,ptin:_node_9043,varname:node_9043,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c29c08dd1c0b6749b7cd0fcff7a29fd,ntxv:0,isnm:False|UVIN-2835-OUT;n:type:ShaderForge.SFN_Power,id:2835,x:31717,y:33207,varname:node_2835,prsc:2|EXP-6353-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6353,x:31510,y:33355,ptovrint:False,ptlb:node_6353,ptin:_node_6353,varname:node_6353,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_TexCoord,id:2323,x:31190,y:33631,varname:node_2323,prsc:2,uv:0;n:type:ShaderForge.SFN_Power,id:5533,x:31402,y:33816,varname:node_5533,prsc:2|VAL-9349-OUT,EXP-9737-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:9349,x:31382,y:33601,varname:node_9349,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2323-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4853,x:31730,y:33587,ptovrint:False,ptlb:node_4853,ptin:_node_4853,varname:node_4853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c29c08dd1c0b6749b7cd0fcff7a29fd,ntxv:0,isnm:False|UVIN-410-OUT;n:type:ShaderForge.SFN_OneMinus,id:410,x:31603,y:33816,varname:node_410,prsc:2|IN-5533-OUT;n:type:ShaderForge.SFN_Add,id:8373,x:32223,y:33197,varname:node_8373,prsc:2|A-9043-RGB,B-6203-OUT;n:type:ShaderForge.SFN_Time,id:6382,x:31077,y:33471,varname:node_6382,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3006,x:31239,y:33432,varname:node_3006,prsc:2|A-4761-OUT,B-6382-TSL;n:type:ShaderForge.SFN_ValueProperty,id:4761,x:31090,y:33400,ptovrint:False,ptlb:node_6353_copy_copy,ptin:_node_6353_copy_copy,varname:_node_6353_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_TexCoord,id:9737,x:30815,y:33940,varname:node_9737,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:5399,x:31340,y:34002,ptovrint:False,ptlb:node_9043_copy,ptin:_node_9043_copy,varname:_node_9043_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c29c08dd1c0b6749b7cd0fcff7a29fd,ntxv:0,isnm:False|UVIN-6237-OUT;n:type:ShaderForge.SFN_Power,id:6237,x:31076,y:34042,varname:node_6237,prsc:2|VAL-9737-UVOUT,EXP-9468-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9468,x:30854,y:34160,ptovrint:False,ptlb:node_6353_copy,ptin:_node_6353_copy,varname:_node_6353_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_TexCoord,id:2582,x:30864,y:34320,varname:node_2582,prsc:2,uv:0;n:type:ShaderForge.SFN_Power,id:2820,x:31110,y:34437,varname:node_2820,prsc:2|VAL-5571-OUT,EXP-5111-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5111,x:30936,y:34544,ptovrint:False,ptlb:node_6353_copy_copy,ptin:_node_6353_copy_copy,varname:_node_6353_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_RemapRange,id:5571,x:31090,y:34222,varname:node_5571,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2582-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1694,x:31438,y:34208,ptovrint:False,ptlb:node_4853_copy,ptin:_node_4853_copy,varname:_node_4853_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c29c08dd1c0b6749b7cd0fcff7a29fd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:3655,x:31311,y:34437,varname:node_3655,prsc:2|IN-2820-OUT;n:type:ShaderForge.SFN_Time,id:7845,x:30421,y:34276,varname:node_7845,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6651,x:30583,y:34237,varname:node_6651,prsc:2|A-555-OUT,B-7845-TSL;n:type:ShaderForge.SFN_ValueProperty,id:555,x:30434,y:34205,ptovrint:False,ptlb:node_6353_copy_copy_copy,ptin:_node_6353_copy_copy_copy,varname:_node_6353_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Lerp,id:6203,x:31935,y:33681,varname:node_6203,prsc:2|A-5399-RGB,B-6651-OUT,T-1694-A;n:type:ShaderForge.SFN_Time,id:7969,x:31955,y:33446,varname:node_7969,prsc:2;n:type:ShaderForge.SFN_Sin,id:435,x:32221,y:33501,varname:node_435,prsc:2|IN-7969-T;n:type:ShaderForge.SFN_Tex2d,id:1806,x:32447,y:33373,ptovrint:False,ptlb:node_1806,ptin:_node_1806,varname:node_1806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:17da6d53ec93a0444bd0f751b1d02477,ntxv:0,isnm:False|MIP-435-OUT;n:type:ShaderForge.SFN_Add,id:2712,x:32646,y:33129,varname:node_2712,prsc:2|A-5964-RGB,B-1806-RGB;n:type:ShaderForge.SFN_Tex2d,id:5646,x:31262,y:32713,ptovrint:False,ptlb:node_5646,ptin:_node_5646,varname:node_5646,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d4140be251f70e74b8dc3bea19a0cddc,ntxv:0,isnm:False|UVIN-7169-UVOUT;n:type:ShaderForge.SFN_Panner,id:3599,x:32686,y:32886,varname:node_3599,prsc:2,spu:0,spv:1|UVIN-5127-UVOUT,DIST-7969-T;n:type:ShaderForge.SFN_TexCoord,id:5127,x:32237,y:32607,varname:node_5127,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:9574,x:32812,y:33219,varname:node_9574,prsc:2,uv:0;n:type:ShaderForge.SFN_Rotator,id:400,x:32099,y:33021,varname:node_400,prsc:2|UVIN-5127-UVOUT;n:type:ShaderForge.SFN_Rotator,id:7169,x:31041,y:32730,varname:node_7169,prsc:2|UVIN-1306-OUT,SPD-8357-OUT;n:type:ShaderForge.SFN_Rotator,id:7897,x:30918,y:32168,varname:node_7897,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:3058,x:30313,y:32601,varname:node_3058,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:6750,x:30492,y:32694,varname:node_6750,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3058-UVOUT;n:type:ShaderForge.SFN_Length,id:241,x:30655,y:32757,varname:node_241,prsc:2|IN-6750-OUT;n:type:ShaderForge.SFN_Append,id:1515,x:30773,y:32597,varname:node_1515,prsc:2|A-3058-U,B-241-OUT,C-241-OUT;n:type:ShaderForge.SFN_ViewVector,id:271,x:30567,y:33058,varname:node_271,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:7109,x:31267,y:32980,varname:node_7109,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1;n:type:ShaderForge.SFN_ViewReflectionVector,id:3280,x:30833,y:33224,varname:node_3280,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:7290,x:30821,y:33058,varname:node_7290,prsc:2;n:type:ShaderForge.SFN_Append,id:1306,x:31005,y:32995,varname:node_1306,prsc:2|A-7290-OUT,B-7290-OUT;n:type:ShaderForge.SFN_Tex2d,id:3319,x:31319,y:32496,ptovrint:False,ptlb:node_3319,ptin:_node_3319,varname:node_3319,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4b8d081e9d114c7f1100f5ab44295342,ntxv:3,isnm:True|UVIN-5832-UVOUT;n:type:ShaderForge.SFN_Rotator,id:5832,x:31056,y:32500,varname:node_5832,prsc:2|UVIN-3058-UVOUT;n:type:ShaderForge.SFN_Slider,id:8357,x:30440,y:32928,ptovrint:False,ptlb:node_8357,ptin:_node_8357,varname:node_8357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2957085,max:1;proporder:5964-358-1813-4982-9043-6353-4853-4761-5399-9468-1694-555-1806-5646-3319-8357;pass:END;sub:END;*/

Shader "Shader Forge/Distortion_Lit" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _node_4982 ("node_4982", Range(0, 1)) = 0.7219598
        _node_9043 ("node_9043", 2D) = "white" {}
        _node_6353 ("node_6353", Float ) = 2
        _node_4853 ("node_4853", 2D) = "white" {}
        _node_6353_copy_copy ("node_6353_copy_copy", Float ) = 4
        _node_9043_copy ("node_9043_copy", 2D) = "white" {}
        _node_6353_copy ("node_6353_copy", Float ) = 2
        _node_4853_copy ("node_4853_copy", 2D) = "white" {}
        _node_6353_copy_copy_copy ("node_6353_copy_copy_copy", Float ) = 4
        _node_1806 ("node_1806", 2D) = "white" {}
        _node_5646 ("node_5646", 2D) = "white" {}
        _node_3319 ("node_3319", 2D) = "bump" {}
        _node_8357 ("node_8357", Range(0, 1)) = 0.2957085
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _node_5646; uniform float4 _node_5646_ST;
            uniform float _node_8357;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 node_9469 = _Time + _TimeEditor;
                float node_7169_ang = node_9469.g;
                float node_7169_spd = _node_8357;
                float node_7169_cos = cos(node_7169_spd*node_7169_ang);
                float node_7169_sin = sin(node_7169_spd*node_7169_ang);
                float2 node_7169_piv = float2(0.5,0.5);
                float node_7290 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float2 node_1306 = float2(node_7290,node_7290);
                float2 node_7169 = (mul(node_1306-node_7169_piv,float2x2( node_7169_cos, -node_7169_sin, node_7169_sin, node_7169_cos))+node_7169_piv);
                float4 _node_5646_var = tex2D(_node_5646,TRANSFORM_TEX(node_7169, _node_5646));
                float3 diffuseColor = _node_5646_var.rgb; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _node_5646; uniform float4 _node_5646_ST;
            uniform float _node_8357;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 node_2316 = _Time + _TimeEditor;
                float node_7169_ang = node_2316.g;
                float node_7169_spd = _node_8357;
                float node_7169_cos = cos(node_7169_spd*node_7169_ang);
                float node_7169_sin = sin(node_7169_spd*node_7169_ang);
                float2 node_7169_piv = float2(0.5,0.5);
                float node_7290 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float2 node_1306 = float2(node_7290,node_7290);
                float2 node_7169 = (mul(node_1306-node_7169_piv,float2x2( node_7169_cos, -node_7169_sin, node_7169_sin, node_7169_cos))+node_7169_piv);
                float4 _node_5646_var = tex2D(_node_5646,TRANSFORM_TEX(node_7169, _node_5646));
                float3 diffuseColor = _node_5646_var.rgb; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _node_5646; uniform float4 _node_5646_ST;
            uniform float _node_8357;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 node_6371 = _Time + _TimeEditor;
                float node_7169_ang = node_6371.g;
                float node_7169_spd = _node_8357;
                float node_7169_cos = cos(node_7169_spd*node_7169_ang);
                float node_7169_sin = sin(node_7169_spd*node_7169_ang);
                float2 node_7169_piv = float2(0.5,0.5);
                float node_7290 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float2 node_1306 = float2(node_7290,node_7290);
                float2 node_7169 = (mul(node_1306-node_7169_piv,float2x2( node_7169_cos, -node_7169_sin, node_7169_sin, node_7169_cos))+node_7169_piv);
                float4 _node_5646_var = tex2D(_node_5646,TRANSFORM_TEX(node_7169, _node_5646));
                float3 diffColor = _node_5646_var.rgb;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

Shader "Custom/AlwaysVisibleGlow"
{
    Properties
    {
        _Color ("Glow Color", Color) = (1,0,0,1)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Overlay" }
        Lighting Off
        ZWrite Off
        ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 _Color;

            struct appdata_t {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata_t v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag () : SV_Target {
                return _Color;
            }
            ENDCG
        }
    }
}
Shader "UI/RoundedCorners"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Radius("Radius", Range(0, 1)) = 0.1
    }
        SubShader
        {
            Tags { "Queue" = "Overlay" }
            Pass
            {
                ZTest Always
                ZWrite Off
                Cull Off
                Lighting Off
                Blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _Radius;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);

                // Calculate rounded corners
                float2 uv = i.uv * 2 - 1;
                float2 absUv = abs(uv);
                float cornerDist = max(absUv.x, absUv.y);

                if (cornerDist > 1 - _Radius)
                {
                    float2 cornerUv = (absUv - 1 + _Radius) / _Radius;
                    if (dot(cornerUv, cornerUv) > 1)
                    {
                        discard;
                    }
                }

                return col;
            }
            ENDCG
        }
        }
}

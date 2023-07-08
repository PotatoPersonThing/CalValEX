sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;
float2 uTargetPosition;

bool isBlank(float4 clr)
{
    return clr.a != 0;
}


float4 SulphuricEffect(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    float4 color2 = tex2D(uImage0, coords);
    float4 color3 = tex2D(uImage0, coords);
    color.r *= 1.22;
    color.g *= 4.22; //d 
    color.b *= 0.22; //d 
    color3.rgb = sin(cos(color.rgb)); //d 
    float wave = 1 - sin(uTime * 5.22f);
    color2.rgb = color2.rgb * wave;
    color.rgb += color2.rgb - color3.rgb;
    return color * sampleColor;
}


technique Technique1
{
    pass SulphuricDyePass
    {
        PixelShader = compile ps_2_0 SulphuricEffect();
    }
}
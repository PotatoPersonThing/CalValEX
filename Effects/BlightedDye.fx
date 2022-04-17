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
float4 uShaderSpecificData;

bool isBlank(float4 clr)
{
    return clr.a != 0;
}


float4 BAstralEffect(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 colour = tex2D(uImage0, coords);
    float luminosity = (colour.r + colour.g + colour.b + colour) / 3;
    float wave = 1 - cos(coords.x + uTime * 2);
    float4 MORE = float4(lerp(uColor, uSecondaryColor, wave), 1);
    colour.rgb = 1.15f* coords.x * uSecondaryColor * luminosity * MORE;
    return colour * sampleColor;
}


technique Technique1
{
    pass BlightedAstralDyePass
    {
        PixelShader = compile ps_2_0 BAstralEffect();
    }
}
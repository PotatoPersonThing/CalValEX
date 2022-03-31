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
bool isBlank(float4 clr)
{
    return clr.a != 0;
}


float4 BAstralYellowEffect(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 colour = tex2D(uImage0, coords);
    float luminosity = (colour.r + colour.g + colour.b + colour) / 3;
    colour.rgb = 1.15f * ((coords.x * uColor) + ((1 - coords.x) * uSecondaryColor)) * luminosity;
    float frameY = (coords.y * uImageSize0.y - uSourceRect.y) / uSourceRect.w;

    return colour * sampleColor;

}


technique Technique1
{
    pass BlightedAstralYellowDyePass
    {
        PixelShader = compile ps_2_0 BAstralYellowEffect();
    }
}
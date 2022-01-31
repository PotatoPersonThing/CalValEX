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


float4 BAstralEffect(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 colour = tex2D(uImage0, coords);
    float luminosity = (colour.r + colour.g + colour.b + colour) / 3;
    /*float frameY = (coords.y * uImageSize0.y - uSourceRect.y) / uSourceRect.w;
    float vwave = 1 + frac(frameY + (uTime * sin(coords.x)));
    float hwave = 1 + (sin(coords.x) + 1) / 3;
    float time = 0.62f + (sin(uTime) + 1) / 3;
    float time2 = 1 + (sin(uTime) + 1) / 2.3f;
    float pixelMov = 0.4f + (sin(coords.x) + 1) / 3;*/ //all this is draedon sulphur dye code i was testing out, ignore this
    colour.rgb = 1.15f* ((coords.x * uColor) + ((1 - coords.x) * uSecondaryColor)) * luminosity;
    /*if (isBlank(colour))
    {
        float2 pixelSize = 1 / uImageSize0; 
        if (!isBlank(tex2D(uImage0, coords + float2(0, -pixelSize.y * 2))))
        {
            return float4 (0.9098f, 0.5294f, 0.9764f, 1) * sampleColor * time * luminosity;
        }
    }
    colour.rgb = 1.25f* (coords.x * vwave * uColor) + ((1 - coords.x) * uSecondaryColor * ((luminosity) * time));*/ //ditto

    return colour * sampleColor;

}


technique Technique1
{
    pass BlightedAstralDyePass
    {
        PixelShader = compile ps_2_0 BAstralEffect();
    }
}
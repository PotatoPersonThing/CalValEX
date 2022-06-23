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

float4 DraedonHologramDye(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float frameY = (coords.y * uImageSize0.y - uSourceRect.y) / uSourceRect.w;
    float mySin3 = sin(uTime * 1.8);
    float mySin2 = clamp(sin(uTime * 3), 0, 0.25);
    float mySin2_1 = clamp(sin(uTime * 3), 0, 0.05);
    float mySin1 = sin(uTime * 2);
    float mySin4 = sin(uTime) * frameY;
    
    if (frameY > 0.10 + mySin4 && frameY < 0.20 + mySin4)
    {
        if (mySin3 > 0.25 && mySin3 < 0.45)
        {
            coords.x = coords.x + 0.2;
        }
    }
    else if (frameY > 0.40 + mySin4 && frameY < 0.60 + mySin4)
    {
        if (mySin3 > 0.25 && mySin3 < 0.45)
        {
            coords.x = coords.x - 0.3;
        }
        
        if (frameY > 0.50 + mySin4 && frameY < 0.55 + mySin4)
        {
            if (mySin3 > 0.25 && mySin3 < 0.45)
            {
                coords.x = coords.x + 0.6;
            }
        }
    }
    float4 color = tex2D(uImage0, coords);
    float luminosity = (color.r + color.g + color.b) / 3;
    
    color.r = (0.121568627 + mySin2_1) * luminosity;
    color.g = (0.734313725 + mySin2) * luminosity;
    color.b = (0.75 + mySin2) * luminosity;
    
    if (frameY > 0.1 + mySin1 && frameY < 0.15 + mySin1)
    {
        color.rgb = 2 * luminosity;
    }
    
    if (frameY > 0.2 + mySin1 && frameY < 0.30 + mySin1)
    {
        color.rgb = 2 * luminosity;
    }
    
    if (frameY > 0.37 + mySin1 && frameY < 0.42 + mySin1)
    {
        color.rgb = 2 * luminosity;
    }
    return color * sampleColor;
}

technique Technique1
{
    pass DraedonHologramDyePass
    {
        PixelShader = compile ps_2_0 DraedonHologramDye();
    }
}
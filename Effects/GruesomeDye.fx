sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
sampler uImage4 : register(s4);
sampler uImage5 : register(s5);
sampler uImage6 : register(s6);
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
float2 uImageSize2;
float2 uImageSize3;
float2 uImageSize4;
float2 uImageSize5;
float2 uImageSize6;

// Many of the offsets in this shader based on offset math in Gruesome Eminence's parallax layering.
// Some things deviate from this, however, since the spaces in which texture coordinates reside differ (relative to the entire screen versus relative to the player sheet, to be specific)

float2 ToUnitVector(float angle)
{
    return float2(cos(angle), sin(angle));
}

float2 RotateBy(float2 v, float angle)
{
    float c = cos(angle);
    float s = sin(angle);
    return float2(v.x * c - v.y * s, v.x * s + v.y * c);
}

float4 PixelShaderFunction(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float frameY = (coords.y * uImageSize0.y - uSourceRect.y) / uSourceRect.w;
    float4 color = tex2D(uImage0, coords);    
    float2 frameCoords = float2(coords.x, frameY) * 0.1;
    
    float2 layer1Offset = float2(uTime * 0.18, 0);
    float4 layer1Color = tex2D(uImage1, frameCoords + layer1Offset);
    
    float2 layer2Offset = RotateBy(cos(uTime * 0.041) * 2, cos(uTime * 0.08) * 0.97);
    float4 layer2Color = tex2D(uImage2, frameCoords + layer2Offset);
    
    float2 layer3Offset = ToUnitVector(uTime * 1.3) * 0.096;
    layer3Offset.y += cos(uTime * 0.161f) * 0.5f + 0.5f;
    float4 layer3Color = tex2D(uImage3, frameCoords + layer3Offset);
    
    float2 layer4Offset = float2(uTime * -0.09, 0) + ToUnitVector(uTime * 0.98) * 0.13;
    float4 layer4Color = tex2D(uImage4, frameCoords + layer4Offset);
    
    float2 layer5Offset = float2(uTime * -0.109, 0) + ToUnitVector(uTime * 1.07) * 0.17;
    float4 layer5Color = tex2D(uImage5, frameCoords + layer5Offset);
    
    float2 layer6Offset = ToUnitVector(uTime * -0.97) * 0.15;
    layer6Offset.y += cos(uTime * -0.137f) * 0.5f + 0.5f;
    float4 layer6Color = tex2D(uImage5, frameCoords + layer6Offset);
    
    float4 gasColor = layer1Color;
    if (any(layer2Color))
        gasColor = layer2Color;
    if (any(layer3Color))
        gasColor = layer3Color;
    if (any(layer4Color))
        gasColor = layer4Color;
    if (any(layer5Color))
        gasColor = layer5Color;
    if (any(layer6Color))
        gasColor = layer6Color;
    
    color = float4(lerp(color.rgb, gasColor.rgb, 0.925), 1) * color.a;
    return color * sampleColor;
}

technique Technique1
{
    pass DyePass
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}

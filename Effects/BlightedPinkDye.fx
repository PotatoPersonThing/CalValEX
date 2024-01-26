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
float2 uTargetPosition;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;

float4 PixelShaderFunction(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float2 framedCoords = (coords * uImageSize0 - uSourceRect.xy) / uSourceRect.zw * 0.5;


    float3 goldColor = float3(213 / 255.0, 16/ 255.0, 227/ 255.0);
float4 noiseColor = tex2D(uImage1, float2(framedCoords.x, framedCoords.y + uTime * 0.22));
float4 color = tex2D(uImage0, coords);
float shineFactor = pow(noiseColor.r, 0.2);
color.rgb = (length(color.rgb) <= 0.5) ? 2 * color.rgb * goldColor : 1 - 2 * (1 - color.rgb) * (1 - goldColor);
    
    return (color + noiseColor * 0.45) * sampleColor * color.a;
}
technique Technique1
{
    pass DyePass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}
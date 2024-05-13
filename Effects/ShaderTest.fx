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

float3 hsb2rgb( in float3 c ){
    float3 rgb = clamp(abs(fmod(c.x* 6.0 + float3(0.0, 4.0, 2.0), 6.0) -3.0) -1.0, 0.0, 1.0 );
    rgb = rgb*rgb*(3.0-2.0*rgb);
    return c.z * lerp(1, rgb, c.y);
}


float4 PixelShaderFunction(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float2 st = (coords * uImageSize0 - uSourceRect.xy) / uSourceRect.zw;
    st *= 2220;
    float3 color = float3(0, 0, 0);
    float4 ogColor = tex2D(uImage0, coords);

    // Use polar coordinates instead of cartesian
    float2 toCenter = 0.5-st;
    float angle = atan2(toCenter.y,toCenter.x);
    float radius = sin(length(toCenter)*(uTime * 0.2));

    // Map the angle (-PI to PI) to the Hue (from 0 to 1)
    // and the Saturation to the radius

    color = float3(0,radius,0);

    float4 returnColor = float4(color.r, color.g, color.b, 1) * ogColor;

    return returnColor;
}


technique Technique1
{
    pass DyePass
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
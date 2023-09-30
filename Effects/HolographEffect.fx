sampler2D uImage0 : register(s0);
float uTime;
float brightnesses[10];
float3 colors[10];
float baseToScreenPercent;
float baseToMapPercent;

float4 Screen(float4 base, float4 overlay)
{
    return 1 - ((1 - (base)) * (1 - (overlay)));
}

float3 GradientMap(float brightness, int gradientSegments, float segmentBrightness[10], float3 segmentColors[10])
{
    
    for (int i = 1; i < gradientSegments; i++)
    {
        float currentBrightness = segmentBrightness[i];
        
        if (currentBrightness >= brightness)
        {
            if (currentBrightness == brightness)
            {
                return segmentColors[i];
            }
            
            float previousBrightness = segmentBrightness[i - 1];
            float segmentLenght = currentBrightness - previousBrightness;
            float segmentProgress = (brightness - previousBrightness) / segmentLenght;
            
            return lerp(segmentColors[i - 1], segmentColors[i], segmentProgress);
        }
    }
    
    return segmentColors[gradientSegments - 1];
}

float4 PixelShaderFunction(float4 baseColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 img = tex2D(uImage0, coords);
    float brightness = (img.r + img.g + img.b) / 3;
    float4 map = float4(GradientMap(brightness, 10, brightnesses, colors), 1);
    if (length(img) > 0)
        return lerp(lerp(img * baseColor, map, baseToMapPercent), Screen(lerp(img * baseColor, map, baseToMapPercent), map), baseToScreenPercent);
    return 0;
}

technique Technique1
{
    pass LiquidPass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}
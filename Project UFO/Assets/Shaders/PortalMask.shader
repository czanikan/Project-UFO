Shader "Custom/PortalMask"
{
    SubShader
    {
        Tags { "Queue"="Transparent-1" }
        
        ZWrite On
        ColorMask 0

        Pass {}
    }
}

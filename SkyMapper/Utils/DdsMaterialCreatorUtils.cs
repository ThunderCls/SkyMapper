using System.Runtime.InteropServices;

namespace SkyMapper.Utils;

public static class DdsMaterialCreatorUtils
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ComplexMaterialArgs
    {
        [MarshalAs(UnmanagedType.LPStr)] public string EnvironmentPath;        // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string GlossinessPath;         // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string MetallicPath;         // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string HeightPath;           // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string Name;           // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string OutputPath;      // Pointer to C string
        [MarshalAs(UnmanagedType.Bool)] public bool HighQuality;
        [MarshalAs(UnmanagedType.Bool)] public bool ArchaicFormat;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct TerrainParallaxArgs
    {
        [MarshalAs(UnmanagedType.LPStr)] public string DiffusePath;        // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string HeightPath;           // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string Name;           // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string OutputPath;      // Pointer to C string
        [MarshalAs(UnmanagedType.Bool)] public bool HighQuality;
        [MarshalAs(UnmanagedType.Bool)] public bool ArchaicFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TextureToImageArgs
    {
        [MarshalAs(UnmanagedType.LPStr)] public string TexturePath;           // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string OutputPath;      // Pointer to C string
        [MarshalAs(UnmanagedType.Bool)] public bool ExtractAlpha;
        [MarshalAs(UnmanagedType.Bool)] public bool HighQuality;
        [MarshalAs(UnmanagedType.Bool)] public bool ArchaicFormat;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageToTextureArgs
    {
        [MarshalAs(UnmanagedType.LPStr)] public string ImagePath;           // Pointer to C string
        [MarshalAs(UnmanagedType.LPStr)] public string Output;      // Pointer to C string
        [MarshalAs(UnmanagedType.Bool)] public bool HighQuality;
        [MarshalAs(UnmanagedType.Bool)] public bool ArchaicFormat;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    private struct MaterialCreatorResponse
    {
        public IntPtr errorMessage;
    }
    
    [DllImport(
        "ThirdParty/DdsMaterialCreator/dds_material_creator.dll", 
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "create_complex_material_map")]
    private static extern bool CreateComplexMaterialMap(
        ref ComplexMaterialArgs args, 
        ref MaterialCreatorResponse response);
    
    [DllImport(
        "ThirdParty/DdsMaterialCreator/dds_material_creator.dll", 
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "create_terrain_parallax_map")]
    private static extern bool CreateTerrainParallaxMap(
        ref TerrainParallaxArgs args, 
        ref MaterialCreatorResponse response);
    
    [DllImport(
        "ThirdParty/DdsMaterialCreator/dds_material_creator.dll", 
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "texture_to_image")]
    private static extern bool TextureToImage(
        ref TextureToImageArgs args, 
        ref MaterialCreatorResponse response);
    
    [DllImport(
        "ThirdParty/DdsMaterialCreator/dds_material_creator.dll", 
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "image_to_texture")]
    private static extern bool ImageToTexture(
        ref ImageToTextureArgs args, 
        ref MaterialCreatorResponse response);

    private delegate bool MaterialCreatorDelegate<T>(ref T args, ref MaterialCreatorResponse response);
    
    private static bool CallMaterialCreatorStub<T>(
        MaterialCreatorDelegate<T> materialCreatorFunc,
        ref T args, 
        out string? errorMessage)
    {
        const int errorBufferSize = 1024;
        var errorBuffer = Marshal.AllocHGlobal(errorBufferSize);
        var response = new MaterialCreatorResponse
        {
            errorMessage = errorBuffer
        };

        try
        {
            if (!materialCreatorFunc(ref args, ref response))
            {
                errorMessage = Marshal.PtrToStringAnsi(errorBuffer) ?? "Unknown error";
                return false;
            }
        }
        finally
        {
            Marshal.FreeHGlobal(errorBuffer);
        }
        
        errorMessage = null;
        return true;
    }
    
    public static bool CreateTerrainParallaxMap(ref TerrainParallaxArgs args, out string? errorMessage) => 
        CallMaterialCreatorStub(CreateTerrainParallaxMap, ref args, out errorMessage);

    public static bool CreateComplexMaterialMap(ref ComplexMaterialArgs args, out string? errorMessage) => 
        CallMaterialCreatorStub(CreateComplexMaterialMap, ref args, out errorMessage);
    
    public static bool TextureToImage(ref TextureToImageArgs args, out string? errorMessage) => 
        CallMaterialCreatorStub(TextureToImage, ref args, out errorMessage);
    
    public static bool ImageToTexture(ref ImageToTextureArgs args, out string? errorMessage) => 
        CallMaterialCreatorStub(ImageToTexture, ref args, out errorMessage);
}
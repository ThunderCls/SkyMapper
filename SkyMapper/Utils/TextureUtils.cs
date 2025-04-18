using System.Diagnostics;
using System.Text.RegularExpressions;
using DirectXTexNet;
using ImageMagick;

namespace SkyMapper.Utils;

public static class TextureUtils
{
    public static async Task<string> ConvertToPng(string inputFile, string destinationDirectory)
    {
        try
        {
            using var image = new MagickImage(inputFile);
            // Remove alpha channel
            image.Alpha(AlphaOption.Off);
            image.BackgroundColor = new MagickColor(0, 0, 0, 0); //MagickColors.Transparent;
            image.Resize(2048, 2048);
            var outputFile = Path.Combine(
                destinationDirectory,
                Path.GetFileNameWithoutExtension(inputFile) + ".png");
            await image.WriteAsync(outputFile);
            return outputFile;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"ConvertToPNG failed for {inputFile} - {e}");
            throw;
        }
    }

    public static async Task SetHeightMapIntensity(string inputFile, double contrast = -88)
    {
        try
        {
            using var image = new MagickImage(inputFile);
            image.BrightnessContrast(new Percentage(-25), new Percentage(contrast));
            await image.WriteAsync(inputFile);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"SetHeightMapIntensity failed for {inputFile} - {e}");
            throw;
        }
    }

    public static async Task ConvertToDds(string inputFile)
    {
        try
        {
            using var scratchImage = TexHelper.Instance.LoadFromWICFile(inputFile, WIC_FLAGS.NONE);
            var resizedImage = ResizeToPowerOfTwo(scratchImage, 1024);
            // Compress the image to BC4_UNORM format
            var compressedImage = resizedImage.Compress(DXGI_FORMAT.BC4_UNORM, TEX_COMPRESS_FLAGS.DEFAULT, 0.5f);
            var parallaxTexture = Regex.Replace(inputFile, @"_p\.png$", "_p.dds", RegexOptions.IgnoreCase);
            await Task.Run(() => compressedImage.SaveToDDSFile(DDS_FLAGS.NONE, parallaxTexture));
        }
        catch (Exception e)
        {
            Debug.WriteLine($"ConvertToDDS failed for {inputFile} - {e}");
            throw;
        }
    }

    private static ScratchImage ResizeToPowerOfTwo(ScratchImage image, int maxHeight)
    {
        var metadata = image.GetMetadata();

        // Calculate new dimensions (power of two, maintaining aspect ratio)
        var newWidth = (int)Math.Pow(2, Math.Floor(Math.Log(metadata.Width, 2)));
        var newHeight = (int)Math.Pow(2, Math.Floor(Math.Log(metadata.Height, 2)));

        // Ensure the height does not exceed the specified maximum
        if (newHeight > maxHeight)
        {
            newHeight = maxHeight;
            newWidth = (int)(metadata.Width * ((double)newHeight / metadata.Height));
            newWidth = (int)Math.Pow(2, Math.Floor(Math.Log(newWidth, 2))); // Ensure width is also a power of two
        }

        return image.Resize(newWidth, newHeight, TEX_FILTER_FLAGS.SEPARATE_ALPHA);
    }
}

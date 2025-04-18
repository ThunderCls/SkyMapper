using System.Security.Cryptography;
using System.Text;

namespace SkyMapper.Utils;

public static class CryptoUtils
{
    public enum HashType
    {
        MD5,
        SHA1,
        SHA256,
        SHA512
    }

    public static string ComputeFileHash(string filePath, HashType hashType = HashType.MD5)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file was not found", filePath);
        }

        using var stream = File.OpenRead(filePath);
        byte[] hashBytes;

        switch (hashType)
        {
            case HashType.MD5:
                using (var md5 = MD5.Create())
                    hashBytes = md5.ComputeHash(stream);
                break;
            case HashType.SHA1:
                using (var sha1 = SHA1.Create())
                    hashBytes = sha1.ComputeHash(stream);
                break;
            case HashType.SHA256:
                using (var sha256 = SHA256.Create())
                    hashBytes = sha256.ComputeHash(stream);
                break;
            case HashType.SHA512:
                using (var sha512 = SHA512.Create())
                    hashBytes = sha512.ComputeHash(stream);
                break;
            default:
                throw new ArgumentException("Unsupported hash type", nameof(hashType));
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2"));
        }

        return sb.ToString();
    }
}

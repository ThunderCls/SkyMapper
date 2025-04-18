using Microsoft.Win32;

namespace SkyMapper.Utils;

public static class RegistryUtils
{
    private const string InstallLocationValue = "InstallLocation";
    private static List<string> _keys =
    [
        @"SOFTWARE\WOW6432Node\Bethesda Softworks\Skyrim Special Edition",
        @"SOFTWARE\WOW6432Node\Bethesda Softworks\Skyrim Anniversary Edition",
        @"SOFTWARE\WOW6432Node\Bethesda Softworks\Skyrim VR"
    ];
    
    public static string? GetGameInstallLocation()
    {
        RegistryKey? gameKey = null;
        foreach (var key in _keys)
        {
            gameKey = Registry.LocalMachine.OpenSubKey(key);
            if (gameKey is not null) break;
        }
        
        return gameKey?.GetValue(InstallLocationValue)?.ToString();
    }
}
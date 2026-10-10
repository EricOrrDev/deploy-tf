using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;
using DeployTf.Core.Services;

namespace DeployTf.Desktop.Services;

public class DesktopFileSystem : IFileSystem
{
    public string PlatformName => "Desktop (Photino / Windows)";

    public bool CanDeployDirectly => true;

    public Task<string> GetDefaultTf2PathAsync()
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // 1. Try checking standard 64-bit/32-bit Steam path in registry
                using var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam")
                                ?? Registry.LocalMachine.OpenSubKey(@"Software\Valve\Steam")
                                ?? Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Valve\Steam");

                if (key?.GetValue("SteamPath") is string steamPath)
                {
                    steamPath = steamPath.Replace('/', '\\');
                    var directTfCfg = Path.Combine(steamPath, "steamapps", "common", "Team Fortress 2", "tf", "cfg");
                    if (Directory.Exists(directTfCfg))
                    {
                        return Task.FromResult(directTfCfg);
                    }
                }

                // 2. Try default location
                var defaultLoc = @"C:\Program Files (x86)\Steam\steamapps\common\Team Fortress 2\tf\cfg";
                if (Directory.Exists(defaultLoc))
                {
                    return Task.FromResult(defaultLoc);
                }
            }
        }
        catch
        {
            // Fall through to fallback
        }

        return Task.FromResult(@"C:\Program Files (x86)\Steam\steamapps\common\Team Fortress 2\tf\cfg");
    }
}

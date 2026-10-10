namespace DeployTf.Core.Services;

public interface IFileSystem
{
    /// <summary>
    /// Friendly display name for the runtime platform host.
    /// </summary>
    string PlatformName { get; }

    /// <summary>
    /// Indicates whether configs can be written directly to the TF2 directory.
    /// </summary>
    bool CanDeployDirectly { get; }

    /// <summary>
    /// Attempts to retrieve or guess the default TF2 install directory.
    /// </summary>
    Task<string> GetDefaultTf2PathAsync();
}

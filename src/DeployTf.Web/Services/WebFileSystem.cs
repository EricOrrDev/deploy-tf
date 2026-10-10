using System.Threading.Tasks;
using DeployTf.Core.Services;

namespace DeployTf.Web.Services;

public class WebFileSystem : IFileSystem
{
    public string PlatformName => "Web (Blazor WebAssembly / Azure Static)";

    public bool CanDeployDirectly => false;

    public Task<string> GetDefaultTf2PathAsync()
    {
        return Task.FromResult("N/A (Browser Client - Zip Download Mode)");
    }
}

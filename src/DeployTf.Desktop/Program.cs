using System;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using DeployTf.Core;
using DeployTf.Core.Services;
using DeployTf.Desktop.Services;

namespace DeployTf.Desktop;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.Services.AddLogging();
        appBuilder.Services.AddSingleton<IFileSystem, DesktopFileSystem>();

        appBuilder.RootComponents.Add<App>("#app");

        var app = appBuilder.Build();

        app.MainWindow
            .SetTitle("Deploy.TF - Config Generator")
            .SetSize(1200, 800)
            .Center();

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal Exception", error.ExceptionObject?.ToString() ?? "Unknown error");
        };

        app.Run();
    }
}

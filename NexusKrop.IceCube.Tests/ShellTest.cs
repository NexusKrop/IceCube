namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Util;
using System;
using System.Runtime.Versioning;

public class ShellTest
{
    [Test]
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public void ShellSystemTest()
    {
        if (!OperatingSystem.IsWindows()
    && !OperatingSystem.IsLinux())
        {
            Assert.Warn("Not a supported platform");
            Assert.Pass();
        }

        Assert.DoesNotThrow(() => Shell.System("echo test"));
    }

    [Test]
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public void ShellAvailableTest()
    {
        if (!OperatingSystem.IsWindows()
            && !OperatingSystem.IsLinux())
        {
            Assert.Warn("Not a supported platform");
            Assert.Pass();
        }

        Assert.That(Shell.IsAvailable());
    }
}

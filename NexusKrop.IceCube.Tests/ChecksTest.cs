namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class ChecksTest
{
    [TestMethod]
    public void ArgNotNull_ThrowsWhenNull()
    {
        var x = Assert.ThrowsException<ArgumentNullException>(() => ArgNotNull_Internal(null));
        Assert.AreEqual("arg", x.ParamName);
    }

    [TestMethod]
    public void ArgNotNullOrEmpty_ThrowsWhenEmpty()
    {
        var x = Assert.ThrowsException<ArgumentException>(() => ArgNotNullOrWhitespace_Internal(string.Empty));
        Assert.AreEqual("arg", x.ParamName);
    }

    [TestMethod]
    public void ArgNotNullOrEmpty_ThrowsWhenWhitespace()
    {
        var x = Assert.ThrowsException<ArgumentException>(() => ArgNotNullOrWhitespace_Internal("    "));
        Assert.AreEqual("arg", x.ParamName);
    }

    [TestMethod]
    public void FileExists_ThrowsIfNotExist()
    {
        Assert.ThrowsException<FileNotFoundException>(() =>
            Checks.FileExists("/asdasd/as/f/as/fas/d/asd/as/ds/"));
    }

    [TestMethod]
    public void DirectoryExists_ThrowsIfNotExist()
    {
        Assert.ThrowsException<DirectoryNotFoundException>(() =>
            Checks.DirectoryExists("/asdf/ew/g/rr/a/e/gwe/fw/ef"));
    }

    [TestMethod]
    public void OsPlatformCheckTest()
    {
        if (OperatingSystem.IsWindows())
        {
            Checks.OnWindows();
        }
        else if (OperatingSystem.IsLinux())
        {
            Checks.OnLinux();
        }
        else
        {
            Assert.Fail("Unknown OS platform.");
        }
    }

    private static void ArgNotNullOrWhitespace_Internal(string? arg)
    {
        Checks.ArgNotNullOrWhitespace(arg);
    }

    private static void ArgNotNull_Internal(string? arg)
    {
        Checks.ArgNotNull(arg);
    }
}
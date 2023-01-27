namespace NexusKrop.IceCube.Exceptions;
using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides methods to check and assert certain conditions.
/// </summary>
public static class Checks
{
#if NET6_0_OR_GREATER
    public static T ArgNotNull<T>(T value, [CallerArgumentExpression("value")] string argName = "???")
#else
    public static T ArgNotNull<T>(T value, string argName)
#endif
    {
        if (value == null) throw new ArgumentNullException(argName);

        return value;
    }

#if NET6_0_OR_GREATER
    public static void NotNullOrWhitespace(string value, [CallerArgumentExpression("value")] string? argName = "???")
#else
    public static void NotNullOrWhitespace(string value, string argName)
#endif
    {
        if (value == null) throw new ArgumentNullException(argName);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(string.Format(ExceptionHelperResources.StringWhitespace, argName), argName);
        }
    }

    /// <summary>
    /// Throws <see cref="FileNotFoundException"/> if the specified file does not exist.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <exception cref="FileNotFoundException">The file specified does not exist.</exception>
    public static void FileExists(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException(string.Format(ExceptionHelperResources.FileNotFound,
                fileName), fileName);
        }
    }

    /// <summary>
    /// Throws <see cref="DirectoryNotFoundException"/> if the specified directory does not exist.
    /// </summary>
    /// <param name="directoryName">The name of the directory.</param>
    /// <exception cref="DirectoryNotFoundException">The directory specified does not exist.</exception>
    public static void DirectoryExists(string directoryName)
    {
        if (!Directory.Exists(directoryName))
        {
            throw new DirectoryNotFoundException(string.Format(ExceptionHelperResources.DirectoryNotFound,
                directoryName));
        }
    }

    /// <summary>
    /// Throws <see cref="NotSupportedException"/> if the current platform is not Microsoft Windows.
    /// </summary>
    public static void OnWindows()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new NotSupportedException(string.Format(ExceptionHelperResources.PlatformRequired,
                "windows"));
        }
    }

    /// <summary>
    /// Throws <see cref="NotSupportedException"/> if the current platform is not Microsoft Windows
    /// with version at least specified in <paramref name="major"/>.
    /// </summary>
    /// <param name="major">The version.</param>
    /// <exception cref="NotSupportedException">The current platform is not Microsoft Windows, or the version is below the required.</exception>
    public static void OnWindows(int major)
    {
        if (!OperatingSystem.IsWindowsVersionAtLeast(major))
        {
            throw new NotSupportedException(string.Format(ExceptionHelperResources.PlatformVersionRequired,
                "windows", major));
        }
    }

    /// <summary>
    /// Throws <see cref="NotSupportedException"/> if the current platform is not GNU/Linux or any other
    /// Linux that is supported by .NET.
    /// </summary>
    public static void OnLinux()
    {
        if (!OperatingSystem.IsLinux())
        {
            throw new NotSupportedException(string.Format(ExceptionHelperResources.PlatformRequired,
                "linux"));
        }
    }
}

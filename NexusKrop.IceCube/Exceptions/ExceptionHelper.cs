namespace NexusKrop.IceCube.Exceptions;
using System;

public static class ExceptionHelper
{
    /// <summary>
    /// Throws <see cref="FileNotFoundException"/> if the specified file does not exist.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <exception cref="FileNotFoundException">The file specified does not exist.</exception>
    public static void ThrowIfFileNotExist(string fileName)
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
    public static void ThrowIfDirectoryNotExist(string directoryName)
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
    public static void ThrowIfNotOnWindows()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new NotSupportedException(string.Format(ExceptionHelperResources.PlatformRequired,
                "windows"));
        }
    }

    /// <summary>
    /// Throws <see cref="NotSupportedException"/> if the current platform is not GNU/Linux or any other
    /// Linux that is supported by .NET.
    /// </summary>
    public static void ThrowIfNotOnLinux()
    {
        if (!OperatingSystem.IsLinux())
        {
            throw new NotSupportedException(string.Format(ExceptionHelperResources.PlatformRequired,
                "linux"));
        }
    }
}

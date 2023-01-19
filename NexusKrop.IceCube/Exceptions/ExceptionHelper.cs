namespace NexusKrop.IceCube.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

// Copyright (C) 2023 NexusKrop & contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace NexusKrop.IceCube.Exceptions;
using System;
using System.Diagnostics;
using System.IO;
#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

/// <summary>
/// Provides methods to check and assert certain conditions.
/// </summary>
public static class Checks
{
    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the specified <paramref name="process"/> is <see langword="null"/> or has exited.
    /// </summary>
    /// <param name="process">The process to check.</param>
    /// <param name="argName">The name of the argument. On .NET 6+, the name of the argument that was checked for is automatically determined by runtime
    /// and thus should not be passed explicitly.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
#if NET6_0_OR_GREATER
    public static Process ProcessRunning(Process process, [CallerArgumentExpression("process")] string argName = "???")
#else
    public static Process ProcessRunning(Process process, string argName)
#endif
    {
        if (process == null) throw new ArgumentNullException(argName);
        if (process.HasExited) throw new ArgumentException(ExceptionHelperResources.ProcessExited, argName);

        return process;
    }

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
    public static void ArgNotNullOrWhitespace(string? value, [CallerArgumentExpression("value")] string? argName = "???")
#else
    public static void ArgNotNullOrWhitespace(string value, string argName)
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

#if NET6_0_OR_GREATER
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
#endif
}

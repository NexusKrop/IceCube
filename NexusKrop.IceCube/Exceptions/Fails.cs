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
using System.IO;

/// <summary>
/// Provides methods to assist in creation and throwing of exceptions.
/// </summary>
/// <remarks>
/// <note type="warning">
/// One common error when using the methods inside <see cref="Fails"/> class is not throwing the exceptions
/// that the methods have created. The methods <b>does not</b> throw any exceptions; they just create and returns them.
/// </note>
/// <para>
/// No methods in this class check for the claimed issue to exist; to enforce a condition, use
/// the methods in <see cref="Checks"/>.
/// </para>
/// </remarks>
public static class Fails
{
    /// <summary>
    /// Creates a <see cref="DirectoryNotFoundException"/> citing that the specified directory was not found.
    /// </summary>
    /// <param name="directoryName">The name of the directory.</param>
    /// <returns>An instance of <see cref="DirectoryNotFoundException"/>.</returns>
    public static DirectoryNotFoundException DirectoryNotFound(string directoryName)
    {
        return new DirectoryNotFoundException(string.Format(ExceptionHelperResources.DirectoryNotFound,
                directoryName));
    }

    /// <summary>
    /// Creates a <see cref="FileNotFoundException"/> citing that the specified file was not found.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <returns>An instance of <see cref="FileNotFoundException"/>.</returns>
    public static FileNotFoundException FileNotFound(string fileName)
    {
        return new FileNotFoundException(string.Format(ExceptionHelperResources.FileNotFound,
                fileName), fileName);
    }

    /// <summary>
    /// Creates a <see cref="PlatformNotSupportedException"/> citing that the specified <paramref name="platform"/> is not supported.
    /// </summary>
    /// <param name="platform">The ID of the platform.</param>
    /// <returns>An instance of <see cref="PlatformNotSupportedException"/>.</returns>
    public static PlatformNotSupportedException PlatformNotSupported(PlatformID platform)
    {
        return new PlatformNotSupportedException(string.Format(ExceptionHelperResources.PlatformNotSupported, platform));
    }

    /// <summary>
    /// <see cref="PlatformNotSupportedException"/> citing that only the specified <paramref name="platform"/> is supported.
    /// </summary>
    /// <param name="platform">The ID of the platform.</param>
    /// <returns>An instance of <see cref="PlatformNotSupportedException"/>.</returns>
    public static PlatformNotSupportedException ExceptedPlatform(string platform)
    {
        return new PlatformNotSupportedException(string.Format(ExceptionHelperResources.PlatformRequired, platform));
    }

    /// <summary>
    /// Creates a <see cref="PlatformNotSupportedException"/> citing that only the specified <paramref name="platform"/> with a major version greater than
    /// <paramref name="major"/> specified is supported.
    /// </summary>
    /// <param name="platform">The ID of the platform.</param>
    /// <param name="major">The minimum major version.</param>
    /// <returns>An instance of <see cref="PlatformNotSupportedException"/>.</returns>
    public static PlatformNotSupportedException ExceptedPlatform(string platform, int major)
    {
        return new PlatformNotSupportedException(string.Format(ExceptionHelperResources.PlatformVersionRequired, platform, major));
    }

    /// <summary>
    /// Creates a <see cref="PlatformNotSupportedException"/> citing that only the specified <paramref name="platform"/> is supported.
    /// </summary>
    /// <param name="platform">The legacy ID of the platform.</param>
    /// <returns>An instance of <see cref="PlatformNotSupportedException"/>.</returns>
    public static PlatformNotSupportedException ExceptedPlatform(PlatformID platform) => ExceptedPlatform(platform.ToString());

    /// <summary>
    /// Creates an <see cref="ArgumentNullException"/> citing that the specified parameter cannot be null.
    /// </summary>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>An instance of <see cref="ArgumentNullException"/>.</returns>
    public static ArgumentNullException ArgumentNull(string paramName)
        => new(paramName, string.Format(ExceptionHelperResources.ArgumentNull, paramName));
}

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

namespace NexusKrop.IceCube.Util;

using NexusKrop.IceCube.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides methods to access the shell and command interpreter API of the operating system.
/// </summary>
public static class Shell
{
    /// <summary>
    /// Opens the specified file via through the shell of the user's operating system. This is equivalent to calling <see cref="Process.Start(string)"/> on .NET Framework.
    /// </summary>
    /// <param name="name">The name of the file.</param>
    /// <remarks>
    /// <note type="warning">
    /// The user must ensure that they trust the specified file, directory or program they execute, and they are sure that whether or not
    /// such file is excepted to be an executable. If such file is not an executable while the caller excepts it is without checking, this could result in malicious code being
    /// executed.
    /// </note>
    /// <para>
    /// On .NET Core, and later, .NET, <see cref="Process.Start(string)"/> no longer defaults <see cref="ProcessStartInfo.UseShellExecute"/> to <see langword="true"/>,
    /// resulting in user have to create a new <see cref="ProcessStartInfo"/> inline. This method creates it internally, and without the need of inline <see cref="ProcessStartInfo"/>,
    /// the code could be simpler and more readable. However, the user should only use this if they specifically needs to <c>ShellExecute</c> the specified file.
    /// </para>
    /// </remarks>
    /// <returns>The process, or <see langword="null"/> if no process were created.</returns>
    /// <seealso cref="Process"/>
    /// <seealso cref="ProcessStartInfo"/>
    /// <seealso cref="Process.Start()"/>
    public static Process? ShellExecute(string name)
    {
        return Process.Start(new ProcessStartInfo(name)
        {
            UseShellExecute = true
        });
    }

#if NET5_0_OR_GREATER

    /// <summary>
    /// Determines whether a shell interpreter is available.
    /// </summary>
    /// <returns><see langword="true"/> if a shell interpreter is available; otherwise <see langword="false"/>.</returns>
    /// <exception cref="PlatformNotSupportedException">The platform is not supported.</exception>
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public static bool IsAvailable()
    {
        if (OperatingSystem.IsLinux())
        {
            return LibC.system(null) != 0;
        }

        if (OperatingSystem.IsWindows())
        {
            return MsvcRuntime._wsystem(null) != 0;
        }

        throw new PlatformNotSupportedException();
    }

    /// <summary>
    /// Executes the specified command via the default shell interpreter of the operating system.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>The exit code of the shell interpreter.</returns>
    /// <exception cref="PlatformNotSupportedException">The platform is not supported.</exception>
    /// <exception cref="ArgumentException">Argument list is too long.</exception>
    /// <exception cref="NotSupportedException">There is no shell interpreter available.</exception>
    /// <exception cref="InvalidOperationException">There is not enough memory to execute the command.</exception>
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public static int System(string command)
    {
        int retVal;

        if (OperatingSystem.IsLinux())
        {
            retVal = LibC.system(command);
        }
        else if (OperatingSystem.IsWindows())
        {
            retVal = MsvcRuntime._wsystem(command);
        }
        else
        {
            throw new PlatformNotSupportedException();
        }

        if (retVal < 0)
        {
            var error = Marshal.GetLastPInvokeError();

            if (error != 0)
            {
                switch (error)
                {
                    default:
                        return retVal;
                    case 7:
                        throw new ArgumentException("Argument list too long.", nameof(command));
                    case 8:
                    case 19:
                        throw new NotSupportedException("No valid command interpreter is available.");
                    case 12:
                        throw new InvalidOperationException("Not enough memory to execute the command.");
                }
            }
        }

        return retVal;
    }
#endif
}

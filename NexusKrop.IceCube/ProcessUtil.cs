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

namespace NexusKrop.IceCube;

using NexusKrop.IceCube.Exceptions;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NexusKrop.IceCube.Interop;

#if NET6_0_OR_GREATER
using System.Runtime.Versioning;
#endif

/// <summary>
/// Provides utilities regarding processes.
/// </summary>
public static class ProcessUtil
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
    /// <seealso cref="Process.Start"/>
    public static Process? ShellExecute(string name)
    {
        return Process.Start(new ProcessStartInfo(name)
        {
            UseShellExecute = true
        });
    }

    /// <summary>
    /// Requests the specified <paramref name="process"/> to shutdown gracefully.
    /// </summary>
    /// <remarks>
    /// <note type="api">
    /// This API is only available in .NET 6.0 or later. Other frameworks are not supported.
    /// </note>
    /// <para>
    /// On GNU/Linux (or any similar platform, such as GNU/Hurd or a BSD with GNU C Library), <c>SIGTERM</c> is sent. This signal instructs the target
    /// process to gracefully end itself, which means the process can do clean up, save its work, etc. before shutting down. However,
    /// if a process is not responding, or encountered deadlock, the program would not be able to respond to the signal and thus does not exit. In this
    /// case, use <see cref="Process.Kill"/>. If such process does not implement <c>SIGTERM</c> handling, the call will terminate the process regardless.
    /// </para>
    /// <para>
    /// <c>SIGTERM</c> may be intercepted and thus be ignored by a process implementing its handlers.
    /// </para>
    /// <note type="warning">
    /// Using Mono with GNU/Linux on any archteciture other than x86-based (including x86-64) is not supported.
    /// </note>
    /// <para>
    /// On Microsoft Windows, this method serves as a wrapper of <see cref="Process.CloseMainWindow"/>.
    /// </para>
    /// </remarks>
    /// <param name="process">The process.</param>
    /// <exception cref="ArgumentException">The <paramref name="process"/> specified is invalid.</exception>
    /// <exception cref="PlatformNotSupportedException">The current operating system is not GNU/Linux (or similar), nor Microsoft Windows.</exception>
    /// <exception cref="UnauthorizedAccessException">The caller does not have permission to end the specified process.</exception>
    public static void EndGracefully(this Process process)
    {
#if NET6_0_OR_GREATER
        var proc = Checks.ArgNotNull(process);
#else
        var proc = Checks.ArgNotNull(process, nameof(process));
#endif

        if (proc.HasExited)
        {
            return;
        }
#if NET6_0_OR_GREATER
        if (OperatingSystem.IsLinux())
        {
            EndGracefullyLinuxInternal(process);
        }
        else if (OperatingSystem.IsWindows())
        {
            process.CloseMainWindow();
        }
        else
        {
            throw new PlatformNotSupportedException("You are not running on GNU/Linux (or similar), or Microsoft Windows.");
        }
#else
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            process.CloseMainWindow();
        }
        else if (Environment.OSVersion.Platform == PlatformID.Unix)
        {
            EndGracefullyLinuxInternal(process);
        }
#endif
    }

#if NET6_0_OR_GREATER
    [SupportedOSPlatform("linux")]
#endif
    private static void EndGracefullyLinuxInternal(Process process)
    {
        if (LibC.kill(process.Id, 15) != 0)
        {
            switch (Marshal.GetLastWin32Error())
            {
                case 1:
                    throw new UnauthorizedAccessException("You are not allowed to end the specified process.");
                case 3:
                    throw new ArgumentException("No such process.", nameof(process));
            }
        }
    }
}

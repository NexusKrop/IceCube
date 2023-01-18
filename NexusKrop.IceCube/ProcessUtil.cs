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
using System.Diagnostics;

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
    public static Process? ShellExecute(string name)
    {
        return Process.Start(new ProcessStartInfo(name)
        {
            UseShellExecute = true
        });
    }
}

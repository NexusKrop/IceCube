namespace NexusKrop.IceCube.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

#if NET6_0_OR_GREATER
[SupportedOSPlatform("windows")]
#endif
internal static partial class MsvcRuntime
{
#if NET7_0_OR_GREATER
    [LibraryImport("msvcrt.dll", SetLastError = true)]
    internal static partial int _wsystem([MarshalAs(UnmanagedType.LPWStr)] string? command);
#else
    [DllImport("msvcrt.dll", SetLastError = true)]
    internal static extern int _wsystem([MarshalAs(UnmanagedType.LPWStr)] string? command);
#endif
}

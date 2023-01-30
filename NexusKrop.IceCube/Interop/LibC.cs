﻿#if NET6_0_OR_GREATER

namespace NexusKrop.IceCube.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

[SupportedOSPlatform("linux")]
internal static class LibC
{
    [DllImport("libc.so.6", SetLastError = true)]
    internal static extern int kill(int pid, int signum);
}

#endif

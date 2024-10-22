using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class CoreGraphics
{
    public const string CoreGraphicsLib = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";

    [DllImport(CoreGraphicsLib)]
    private static extern void CGPathRelease(nint path);
}
using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class Foundation
{
    public const string FoundationLib = "/System/Library/Frameworks/Foundation.framework/Foundation";

    [StructLayout(LayoutKind.Sequential)]
    public struct NSSize
    {
        public double width;
        public double height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NSPoint
    {
        public double x;

        public double y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NSRect
    {
        public NSPoint origin;
        public NSSize size;
    }
}
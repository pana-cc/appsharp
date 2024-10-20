using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class Foundation
{
    public const string FoundationLib = "/System/Library/Frameworks/Foundation.framework/Foundation";

    [DllImport(ObjC.LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint obj, nint sel, NSRect rect);

    [DllImport(ObjC.LibObjCLib, EntryPoint = "objc_msgSend_stret")]
    public static extern nint objc_msgSend_stret(nint obj, nint sel);

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

        public NSRect(double x, double y, double width, double height)
        {
            this.origin.x = x;
            this.origin.y = y;
            this.size.width = width;
            this.size.height = height;
        }
    }
}
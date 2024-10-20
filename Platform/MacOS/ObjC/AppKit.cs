using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public const string AppKitLib = "/System/Library/Frameworks/AppKit.framework/AppKit";

    public static readonly Protocol NSApplicationDelegate = new Protocol("NSApplicationDelegate");

    [Flags]
    public enum NSAutoresizingMaskOptions : int
    {
        NSViewNotSizable = 0,
        NSViewMinXMargin = 1,
        NSViewWidthSizable = 2,
        NSViewMaxXMargin = 4,
        NSViewMinYMargin = 8,
        NSViewHeightSizable = 16,
        NSViewMaxYMargin = 32
    }

    [DllImport(AppKitLib)]
    public static extern nint NSSelectorFromString(nint selector);
}
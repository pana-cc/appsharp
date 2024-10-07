using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public const string AppKitLib = "/System/Library/Frameworks/AppKit.framework/AppKit";

    public static readonly Protocol NSApplicationDelegate = new Protocol("NSApplicationDelegate");

    [DllImport(AppKitLib)]
    public static extern nint NSSelectorFromString(nint selector);
}
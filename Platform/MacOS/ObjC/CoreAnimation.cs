using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class CoreAnimation
{
    public const string CoreAnimationLib = "/System/Library/Frameworks/QuartzCore.framework/QuartzCore";
    public static readonly nint Library = NativeLibrary.Load(CoreAnimationLib);
}
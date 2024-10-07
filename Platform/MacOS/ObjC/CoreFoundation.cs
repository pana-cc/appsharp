using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static class CoreFoundation
{
    public const string CoreFoundationLib = "/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation";

    [DllImport(CoreFoundationLib)]
    public static extern void CFRelease(nint obj);

    public static nint CFString(string str)
    {
        nint cfStr = CFStringCreateWithCString(nint.Zero, str, kCFStringEncodingUTF8);
        if (cfStr == 0)
        {
            throw new ObjCException("Failed to create new CFString.");
        }

        return cfStr;
    }

    [DllImport(CoreFoundationLib)]
    private static extern nint CFStringCreateWithCString(nint allocator, string value, uint encoding);

    private const uint kCFStringEncodingUTF8 = 0x08000100;
}
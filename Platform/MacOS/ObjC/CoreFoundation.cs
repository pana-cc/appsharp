using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static class CoreFoundation
{
    public const string CoreFoundationLib = "/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation";

    public static readonly Sel UTF8StringSel = new Sel("UTF8String");

    [DllImport(CoreFoundationLib)]
    public static extern void CFRelease(nint obj);

    [DllImport(CoreFoundationLib)]
    public static extern void CFRetain(nint obj);

    /// <summary>
    /// Creates a CFStringRef from C# string.
    /// You need to manually release after use.
    /// <exception cref="ObjCException"></exception>
    public static nint CFString(string? str)
    {
        if (str == null)
        {
            return 0;
        }

        nint cfStr = CFStringCreateWithCString(nint.Zero, str, kCFStringEncodingUTF8);
        if (cfStr == 0)
        {
            throw new ObjCException("Failed to create new CFString.");
        }

        return cfStr;
    }

    public static string? ToString(nint cfStringRef)
    {
        return Marshal.PtrToStringUTF8(objc_msgSend_retIntPtr(cfStringRef, UTF8StringSel));
    }

    [DllImport(CoreFoundationLib)]
    private static extern nint CFStringCreateWithCString(nint allocator, string value, uint encoding);

    private const uint kCFStringEncodingUTF8 = 0x08000100;

    /// <summary>
    /// Abstracts away the use of CFString + CFRelease into stack bound:
    /// <code>
    /// using var cfStr = new CFStringRef(str);
    /// </code>
    /// </summary>
    public ref struct CFStringRef
    {
        public readonly nint Id;

        public CFStringRef(nint id)
        {
            this.Id = id;
        }

        public CFStringRef(string? str) : this(CFString(str))
        {
        }

        public void Dispose()
        {
            if (this.Id != 0)
            {
                CFRelease(this.Id);
            }
        }

        public static implicit operator nint(CFStringRef cfStringRef)
        {
            return cfStringRef.Id;
        }
    }
}
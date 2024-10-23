using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class CoreFoundation
{
    /// <summary>
    /// Abstracts away the use of CFString + CFRelease into stack bound:
    /// <code>
    /// using var cfStr = new CFStringRef(str);
    /// </code>
    /// </summary>
    public ref struct CFStringRef
    {
        public readonly nint Self;

        public CFStringRef(nint self)
        {
            if (self == 0)
            {
                throw new ObjCException($"{nameof(CFStringRef)} instantiated with nil self.");
            }

            this.Self = self;
        }

        public CFStringRef(string? str) : this(CFString(str))
        {
        }

        public void Dispose()
        {
            if (this.Self != 0)
            {
                CFRelease(this.Self);
            }
        }

        public static implicit operator nint(CFStringRef cfStringRef) => cfStringRef.Self;

        public static implicit operator string?(CFStringRef cfStringRef) =>
            Marshal.PtrToStringUTF8(
                ObjC.objc_msgSend_retIntPtr(cfStringRef, UTF8StringSel));
    }
}
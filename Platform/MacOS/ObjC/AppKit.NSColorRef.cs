using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public ref struct NSColorRef
    {
        public static readonly Class Class = new Class("NSColor");

        private static Sel ColorWithCalibratedRedGreenBlueAlpha = new Sel("colorWithCalibratedRed:green:blue:alpha:");


        [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
        private static extern nint objc_msgSend_retIntPtr(nint obj, nint sel, double red, double green, double blue, double alpha);

        public readonly nint Self;

        public NSColorRef(nint self)
        {
            if (self == 0)
            {
                throw new ObjCException($"{nameof(NSColorRef)} instantiated with nil self.");
            }

            this.Self = self;
        }

        public static NSColorRef RGBA(double red, double green, double blue, double alpha) => new NSColorRef(objc_msgSend_retIntPtr(Class, ColorWithCalibratedRedGreenBlueAlpha, red, green, blue, alpha));

        public void Dispose()
        {
            if (this.Self != 0)
            {
                CoreFoundation.CFRelease(this.Self);
            }
        }

        public static implicit operator nint(NSColorRef nsColorRef) => nsColorRef.Self;
    }
}
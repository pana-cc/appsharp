using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class CoreGraphics
{
    public ref struct CGColorRef
    {
        [DllImport(CoreGraphicsLib)]
        private static extern nint CGColorCreateGenericRGB(double red, double green, double blue, double alpha);

        [DllImport(CoreGraphicsLib)]
        private static extern void CGColorRelease(nint self);

        public readonly nint Self;

        public CGColorRef(nint self)
        {
            if (self == 0)
            {
                throw new ObjCException($"{nameof(CGColorRef)} instantiated with nil self.");
            }

            this.Self = self;
        }

        public CGColorRef(double red, double green, double blue, double alpha) : this(CGColorCreateGenericRGB(red, green, blue, alpha))
        {
        }

        public void Dispose()
        {
            if (this.Self != 0)
            {
                CGColorRelease(this.Self);
            }
        }

        public static implicit operator nint(CGColorRef cfColorRef) => cfColorRef.Self;
    }
}
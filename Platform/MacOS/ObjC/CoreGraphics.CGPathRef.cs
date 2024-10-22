namespace AppSharp.Platform.MacOS;

public static partial class CoreGraphics
{
    public ref struct CGPathRef
    {
        public readonly nint Self;

        public CGPathRef(nint self)
        {
            if (self == 0)
            {
                throw new ObjCException($"{nameof(CGPathRef)} instantiated with nil self.");
            }

            this.Self = self;
        }

        public void Dispose()
        {
            if (this.Self != 0)
            {
                CGPathRelease(this.Self);
            }
        }

        public static implicit operator nint(CGPathRef cfColorRef) => cfColorRef.Self;
    }
}
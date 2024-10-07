using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class Foundation
{
    public sealed class NSAutoreleasePool : Ref
    {
        public static readonly Class Class = new Class("NSAutoreleasePool");

        public NSAutoreleasePool() : base(Class.New(), true)
        {
        }
    }
}
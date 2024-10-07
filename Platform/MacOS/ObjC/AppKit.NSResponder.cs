using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSResponder : NSObject
    {
        public static new readonly Class Class = new Class("NSResponder");

        public NSResponder(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public override NSResponder Autorelease() => (NSResponder)base.Autorelease();
    }
}
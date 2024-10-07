using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSText : NSView
    {
        public static new readonly Class Class = new Class("NSText");

        public NSText(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSText() : base(Class.New())
        {
        }

        public override NSText Autorelease() => (NSText)base.Autorelease();
    }
}
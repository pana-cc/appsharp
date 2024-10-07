using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSControl : NSView
    {
        public static new readonly Class Class = new Class("NSControl");

        public NSControl(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSControl() : base(Class.New())
        {
        }

        public override NSControl Autorelease() => (NSControl)base.Autorelease();
    }
}
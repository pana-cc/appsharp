using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSTextField : NSControl
    {
        public static new readonly Class Class = new Class("NSTextField");

        public NSTextField(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSTextField() : base(Class.New())
        {
        }

        public override NSTextField Autorelease() => (NSTextField)base.Autorelease();
    }
}
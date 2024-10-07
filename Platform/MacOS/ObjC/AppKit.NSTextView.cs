using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSTextView : NSText
    {
        public static new readonly Class Class = new Class("NSTextView");

        public NSTextView(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSTextView() : base(Class.New())
        {
        }

        public override NSTextView Autorelease() => (NSTextView)base.Autorelease();
    }
}
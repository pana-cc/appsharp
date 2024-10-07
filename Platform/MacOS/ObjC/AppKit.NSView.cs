using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.Foundation;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSView : NSResponder
    {
        public static new readonly Class Class = new Class("NSView");

        public static readonly Sel FrameSel = new Sel("frame");

        public static readonly Sel SetFrameSel = new Sel("setFrame:");

        public NSView(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSView() : base(Class.New())
        {
        }

        public override NSView Autorelease() => (NSView)base.Autorelease();
    }
}
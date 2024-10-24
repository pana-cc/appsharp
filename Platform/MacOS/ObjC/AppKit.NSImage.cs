using static AppSharp.Platform.MacOS.CoreFoundation;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSImage : NSControl
    {
        public static new readonly Class Class = new Class("NSImage");

        private static readonly Sel InitWithContentsOfFileSel = new Sel("initWithContentsOfFile:");

        public NSImage(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSImage() : base(Class.New())
        {
        }

        public static NSImage LoadImageFile(string path)
        {
            var cfStringRef = new CFStringRef(path);
            return new NSImage(objc_msgSend_retIntPtr(Class.New(), InitWithContentsOfFileSel, cfStringRef));
        }

        public override NSImage Autorelease() => (NSImage)base.Autorelease();
    }
}
using System.Dynamic;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSImageView : NSControl
    {
        public static new readonly Class Class = new Class("NSImageView");

        private static readonly Prop ImageProp = new Prop("image", "setImage:");

        private static readonly Sel InitWithImageSel = new Sel("initWithImage:");

        public NSImageView(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSImageView() : base(Class.New())
        {
        }

        public NSImage Image
        {
            // TODO: marshalling for C# created objects...
            get => throw new NotImplementedException();
            set => objc_msgSend(this, ImageProp.SetSel, value);
        }

        public override NSImageView Autorelease() => (NSImageView)base.Autorelease();
    }
}
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

        public static readonly Sel AutoresizesSubviewsSel = new Sel("autoresizesSubviews");

        public static readonly Sel SetAutoresizesSubviewsSel = new Sel("setAutoresizesSubviews:");

        public static readonly Sel NeedsDisplaySel = new Sel("needsDisplay");

        public static readonly Sel SetNeedsDisplaySel = new Sel("setNeedsDisplay:");

        public static readonly Sel AutoresizingMaskSel = new Sel("autoresizingMask");

        public static readonly Sel SetAutoresizingMaskSel = new Sel("setAutoresizingMask:");

        public static readonly Sel TranslatesAutoresizingMaskIntoConstraintsSel = new Sel("translatesAutoresizingMaskIntoConstraints");

        public static readonly Sel SetTranslatesAutoresizingMaskIntoConstraintsSel = new Sel("setTranslatesAutoresizingMaskIntoConstraints:");

        public static readonly Sel AddSubviewSel = new Sel("addSubview:");

        public static readonly Sel FlippedSel = new Sel("flipped");

        public static readonly Sel SetFlippedSel = new Sel("setFlipped:");

        public static readonly Sel WantsLayerSel = new Sel("wantsLayer");

        public static readonly Sel SetWantsLayerSel = new Sel("setWantsLayer:");

        public NSView(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSView() : base(Class.New())
        {
        }

        public NSRect Frame
        {
            get
            {
                // nint rect = objc_msgSend_retIntPtr(this, FrameSel);
                // TODO: Convert from NSRect* to NSRect...
                throw new NotImplementedException();
            }

            set
            {
                objc_msgSend(this, SetFrameSel, value);
            }
        }

        public bool AutoresizesSubviews
        {
            get
            {
                return objc_msgSend_retBool(this, AutoresizesSubviewsSel);
            }

            set
            {
                objc_msgSend(this, SetAutoresizesSubviewsSel, value);
            }
        }

        public NSAutoresizingMaskOptions AutoresizingMask
        {
            get
            {
                return (NSAutoresizingMaskOptions)objc_msgSend_retInt(this, AutoresizingMaskSel);
            }

            set
            {
                objc_msgSend(this, SetAutoresizingMaskSel, (int)value);
            }
        }


        public bool TranslatesAutoresizingMaskIntoConstraints
        {
            get
            {
                return objc_msgSend_retBool(this, TranslatesAutoresizingMaskIntoConstraintsSel);
            }

            set
            {
                objc_msgSend(this, SetTranslatesAutoresizingMaskIntoConstraintsSel, value);
            }
        }

        public bool NeedsDisplay
        {
            get
            {
                return objc_msgSend_retBool(this, NeedsDisplaySel);
            }

            set
            {
                objc_msgSend(this, SetNeedsDisplaySel, value);
            }
        }

        public bool Flipped
        {
            get
            {
                return objc_msgSend_retBool(this, FlippedSel);
            }

            set
            {
                objc_msgSend(this, SetFlippedSel, value);
            }
        }

        public bool WantsLayer
        {
            get
            {
                return objc_msgSend_retBool(this, WantsLayerSel);
            }

            set
            {
                objc_msgSend(this, SetWantsLayerSel, value);
            }
        }

        public override NSView Autorelease() => (NSView)base.Autorelease();

        public void AddSubview(NSView child)
        {
            objc_msgSend(this, AddSubviewSel, child);
        }
    }
}
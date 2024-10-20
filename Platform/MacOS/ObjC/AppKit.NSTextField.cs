using static AppSharp.Platform.MacOS.CoreFoundation;
using static AppSharp.Platform.MacOS.CoreGraphics;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSTextField : NSControl
    {
        public static new readonly Class Class = new Class("NSTextField");

        public static readonly Sel SetStringValueSel = new Sel("setStringValue:");

        public static readonly Sel StringValueSel = new Sel("stringValue");

        public static readonly Sel SetIsBezeledSel = new Sel("setBezeled:");

        public static readonly Sel IsBezeledSel = new Sel("bezeled");

        public static readonly Sel SetIsEditableSel = new Sel("setEditable:");

        public static readonly Sel IsEditableSel = new Sel("editable");

        public static readonly Sel SetDrawsBackgroundSel = new Sel("setDrawsBackground:");

        public static readonly Sel DrawsBackgroundSel = new Sel("drawsBackground");

        public static readonly Sel TextColorSel = new Sel("textColor");

        public static readonly Sel SetTextColorSel = new Sel("setTextColor:");

        public NSTextField(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSTextField() : base(Class.New())
        {
        }

        // StringValue = "Hello World!",

        public string? StringValue
        {
            get
            {
                return CoreFoundation.ToString(objc_msgSend_retIntPtr(this, StringValueSel));
            }

            set
            {
                using var cfStringRef = new CFStringRef(value);
                objc_msgSend(this, SetStringValueSel, cfStringRef.Self);
            }
        }

        public bool IsBezeled
        {
            get
            {
                return objc_msgSend_retBool(this, IsBezeledSel);
            }

            set
            {
                objc_msgSend(this, SetIsBezeledSel, value);
            }
        }

        public bool DrawsBackground
        {
            get
            {
                return objc_msgSend_retBool(this, DrawsBackgroundSel);
            }

            set
            {
                objc_msgSend(this, SetDrawsBackgroundSel, value);
            }
        }

        public bool IsEditable
        {
            get
            {
                return objc_msgSend_retBool(this, IsEditableSel);
            }

            set
            {
                objc_msgSend(this, SetIsEditableSel, value);
            }
        }

        public NSColorRef TextColor
        {
            get
            {
                // What if it is a derived type? Implement "Marshal id ref"
                // TODO: Probably we need to retain it if we want to dispose it later...
                // Or for performance if we will keep it in struct ref - opt out and don't retain or release...
                // return new NSColorRef(objc_msgSend_retIntPtr(this, TextColorSel));
                throw new NotImplementedException();
            }

            set
            {
                objc_msgSend(this, SetTextColorSel, value);
            }
        }

        public override NSTextField Autorelease() => (NSTextField)base.Autorelease();
    }
}
using static AppSharp.Platform.MacOS.CoreFoundation;
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
                objc_msgSend(this, SetStringValueSel, cfStringRef.Id);
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

        public override NSTextField Autorelease() => (NSTextField)base.Autorelease();
    }
}
using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.Foundation;
using static AppSharp.Platform.MacOS.CoreFoundation;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSWindow : NSResponder
    {
        public static new readonly Class Class = new Class("NSWindow");

        public static readonly Sel InitWithContentRectSel = new Sel("initWithContentRect:styleMask:backing:defer:");

        private static readonly Sel SetReleasedWhenClosedSel = new Sel("setReleasedWhenClosed:");
        private static readonly Sel SetAcceptsMouseMovedEventsSel = new Sel("setAcceptsMouseMovedEvents:");
        private static readonly Sel MakeKeyAndOrderFrontSel = new Sel("makeKeyAndOrderFront:");
        private static readonly Sel SetTitleSel = new Sel("setTitle:");

        public NSWindow(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public NSWindow(string title) : this(CreateNSWindowWithTitle(title))
        {
        }

        private static nint CreateNSWindowWithTitle(string title)
        {
            nint nsWindowRef = InitWithContentRectStyleMaskBackingDefer(
                Class.Alloc(),
                rect: new NSRect {
                    origin = new NSPoint {
                        x = 200,
                        y = 200
                    },
                    size = new NSSize {
                        width = 600,
                        height = 400
                    }
                },
                nswindowstylemask: 15,
                nsbackingstoretype: 2,
                defer: false
            );

            objc_msgSend_retIntPtr(nsWindowRef, SetReleasedWhenClosedSel, false);
            objc_msgSend_retIntPtr(nsWindowRef, SetAcceptsMouseMovedEventsSel, true);
            objc_msgSend_retIntPtr(nsWindowRef, MakeKeyAndOrderFrontSel, nint.Zero);

            if (title != null)
            {
                nint titleStr = CFString(title);
                objc_msgSend_retIntPtr(nsWindowRef, SetTitleSel, titleStr);
                CFRelease(titleStr);
            }
            
            return nsWindowRef;
        }

        [DllImport(FoundationLib, EntryPoint = "objc_msgSend")]
        private static extern IntPtr objc_msgSend_retIntPtr(IntPtr obj, IntPtr sel, NSRect rect, uint nswindowstylemask, uint nsbackingstoretype, bool defer);

        [DllImport(CoreFoundationLib, EntryPoint = "objc_msgSend")]
        private static extern IntPtr objc_msgSend_retIntPtr(IntPtr obj, IntPtr sel, NSPoint point);

        [DllImport(CoreFoundationLib, EntryPoint = "objc_msgSend")]
        private static extern IntPtr objc_msgSend_retIntPtr(IntPtr obj, IntPtr sel, NSSize point);

        [DllImport(CoreFoundationLib, EntryPoint = "objc_msgSend")]
        private static extern IntPtr objc_msgSend_retIntPtr(IntPtr obj, IntPtr sel, bool b);

        [DllImport(CoreFoundationLib, EntryPoint = "objc_msgSend")]
        private static extern IntPtr objc_msgSend_retIntPtr(IntPtr obj, IntPtr sel, IntPtr id1);

        protected static nint InitWithContentRectStyleMaskBackingDefer(nint id, NSRect rect, uint nswindowstylemask, uint nsbackingstoretype, bool defer)
            => objc_msgSend_retIntPtr(id, InitWithContentRectSel, rect, nswindowstylemask, nsbackingstoretype, defer);
    }
}
using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.CoreFoundation;
using static AppSharp.Platform.MacOS.Foundation;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public ref struct NSEventRef
    {
        private static readonly Sel TypeSel = new Sel("type");

        private static readonly Sel SubtypeSel = new Sel("type");

        private static readonly Sel LocationInWindowSel = new Sel("locationInWindow");

        public readonly nint Self;

        public NSEventRef(nint self)
        {
            if (self == 0)
            {
                throw new ObjCException($"{nameof(NSEventRef)} instantiated with nil self.");
            }

            this.Self = self;
        }

        public NSEventType Type => (NSEventType)objc_msgSend_retIntPtr(this, TypeSel);

        public NSEventSubtype Subtype => (NSEventSubtype)objc_msgSend_retIntPtr(this, SubtypeSel);

        public NSPoint LocationInWindow
        {
            get
            {
                NSPoint point = objc_msgSend_NSPointRet(this, LocationInWindowSel);
                return point;
            }
        }

        // TODO: Figure out how to do that... This is toast on Arm64!
        [DllImport(ObjC.LibObjCLib, EntryPoint = "objc_msgSend")]
        public static extern NSPoint objc_msgSend_NSPointRet(nint obj, nint sel);

        public void Dispose()
        {
            if (this.Self != 0)
            {
                CFRelease(this.Self);
            }
        }

        public static implicit operator nint(NSEventRef cfStringRef) => cfStringRef.Self;

        public enum NSEventType : long // nint
        {
            LeftMouseDown = 1,
            LeftMouseUp = 2,
            RightMouseDown = 3,
            RightMouseUp = 4,
            MouseMoved = 5,
            LeftMouseDragged = 6,
            RightMouseDragged = 7,
            MouseEntered = 8,
            MouseExited = 9,
            KeyDown = 10,
            KeyUp = 11,
            FlagsChanged = 12,
            AppKitDefined = 13,
            SystemDefined = 14,
            ApplicationDefined = 15,
            Periodic = 16,
            CursorUpdate = 17,
            ScrollWheel = 22,
            TabletPoint = 23,
            TabletProximity = 24,
            OtherMouseDown = 25,
            OtherMouseUp = 26,
            OtherMouseDragged = 27,
            Gesture = 29,
            Magnify = 30,
            Swipe = 31,
            Rotate = 18,
            BeginGesture = 19,
            EndGesture = 20,
            SmartMagnify = 32,
            QuickLook = 33,
            Pressure = 34,
            DirectTouch = 37,
            ChangeMode = 38,
        }

        public enum NSEventSubtype : short
        {
            // event subtypes for NSEventTypeAppKitDefined events
            NSEventSubtypeWindowExposed = 0,
            NSEventSubtypeApplicationActivated = 1,
            NSEventSubtypeApplicationDeactivated = 2,
            NSEventSubtypeWindowMoved = 4,
            NSEventSubtypeScreenChanged = 8,
            
            // event subtypes for NSEventTypeSystemDefined events
            NSEventSubtypePowerOff = 1,
            
            // event subtypes for mouse events
            NSEventSubtypeMouseEvent = 0,
            NSEventSubtypeTabletPoint = 1,
            NSEventSubtypeTabletProximity = 2,
            NSEventSubtypeTouch = 3
        }
    }
}

using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class AppKit
{
    public class NSApplication : NSResponder
    {
        public static new readonly Class Class = new Class("NSApplication");

        public static readonly Sel SharedApplicationSel = new Sel("sharedApplication");
        public static readonly Sel SetActivationPolicySel = new Sel("setActivationPolicy:");

        public static readonly Sel SetDelegateSel = new Sel("setDelegate:");

        public static readonly Sel ActivateSel = new Sel("activate");

        public static readonly Sel ActivateIgnoringOtherAppsSel = new Sel("activateIgnoringOtherApps:");

        public static readonly Sel RunSel = new Sel("run");

        private NSApplication(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public static NSApplication? SharedApplication
        {
            get
            {
                nint id = objc_msgSend_retIntPtr(Class, SharedApplicationSel);
                return id == 0 ? null : new NSApplication(id, false);
            }
        }

        /// <summary>
        /// An Objecitve-C instance implementing NSApplicationDelegate protocol
        /// </summary>
        public Ref Delegate
        {
            set
            {
                objc_msgSend_retIntPtr(this, SetDelegateSel, value);
            }
        }

        public void Activate()
        {
            objc_msgSend(this, ActivateSel);
        }

        public void Run()
        {
            objc_msgSend(this, RunSel);
        }

        public override NSApplication Autorelease() => (NSApplication)base.Autorelease();

        public bool SetActivationPolicy(int v) => objc_msgSend_retBool(this, SetActivationPolicySel, v);
    }
}
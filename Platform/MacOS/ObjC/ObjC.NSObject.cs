using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

/// <summary>
/// Objective-C Runtime.
/// Exposing functions from "/usr/lib/libobjc.A.dylib"
/// https://developer.apple.com/documentation/objectivec/objective-c_runtime
/// </summary>
public static partial class ObjC
{
    public class NSObject : Ref
    {
        public static readonly Class Class = new Class("NSObject");

        public static readonly Sel AutoreleaseSel = new Sel("autorelease");

        public NSObject(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public virtual NSObject Autorelease()
        {
            nint id = objc_msgSend_retIntPtr(this, AutoreleaseSel);
            if (id != this.Id)
            {
                throw new ObjCException("Objective-C autorelease returned different id.");
            }
            
            return this;
        }
    }
}
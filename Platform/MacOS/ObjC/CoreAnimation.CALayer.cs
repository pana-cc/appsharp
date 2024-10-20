using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class CoreAnimation
{
    public class CALayer : NSObject
    {
        public static new readonly Class Class = new Class("CALayer");

        public CALayer() : base(Class.New())
        {
        }

        public CALayer(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }
    }
}
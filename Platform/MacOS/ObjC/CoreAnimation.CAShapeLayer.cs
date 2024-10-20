using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class CoreAnimation
{
    public class CAShapeLayer : CALayer
    {
        public static new readonly Class Class = new Class("CAShapeLayer");

        public CAShapeLayer() : base(Class.New())
        {
        }

        public CAShapeLayer(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }
    }
}
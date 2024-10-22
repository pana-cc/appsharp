using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class CoreAnimation
{
    public class CALayer : NSObject
    {
        public static new readonly Class Class = new Class("CALayer");

        private static readonly Sel InsertSublayerAtIndexSel = new Sel("insertSublayer:atIndex:");

        public CALayer() : base(Class.New())
        {
        }

        public CALayer(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        public void InsertAt(CALayer layer, uint index) => objc_msgSend(this, InsertSublayerAtIndexSel, layer, index);
    }
}
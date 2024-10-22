using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.CoreFoundation;
using static AppSharp.Platform.MacOS.CoreGraphics;
using static AppSharp.Platform.MacOS.ObjC;

namespace AppSharp.Platform.MacOS;

public static partial class CoreAnimation
{
    /// <summary>
    /// https://developer.apple.com/documentation/quartzcore/cashapelayer?language=objc
    /// </summary>
    public class CAShapeLayer : CALayer
    {
        public static new readonly Class Class = new Class("CAShapeLayer");

        public static readonly Sel PathSel = new Sel("path");

        public static readonly Sel SetPathSel = new Sel("setPath:");

        public static readonly Sel SetFillColorSel = new Sel("setFillColor:");

        public static readonly Prop FillColorProp = new Prop("fillColor", "setFillColor:");

        public static readonly Prop StrokeColorProp = new Prop("strokeColor", "setStrokeColor:");

        public static readonly Prop LineWidthProp = new Prop("lineWidth", "setLineWidth:");

        public static readonly Prop FillRuleProp = new Prop("fillRule", "setFillRule:");

        public static readonly Prop LineCapProp = new Prop("lineCap", "setLineCap:");

        public static readonly Prop LineJoinProp = new Prop("lineJoin", "setLineJoin:");

        public static readonly Prop MiterLimitProp = new Prop("miterLimit", "setMiterLimit:");

        public CAShapeLayer() : base(Class.New())
        {
        }

        public CAShapeLayer(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
        {
        }

        // TODO: How CGMutablePathRef could extend CGPathRef
        public nint Path
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                objc_msgSend(this, SetPathSel, value);
            }
        }

        public CGColorRef FillColor
        {
            get => new CGColorRef(objc_msgSend_retIntPtr(this, FillColorProp.GetSel));
            set => objc_msgSend(this, SetFillColorSel, value);
        }

        public CGColorRef StrokeColor
        {
            get => new CGColorRef(objc_msgSend_retIntPtr(this, StrokeColorProp.GetSel));
            set => objc_msgSend(this, StrokeColorProp.SetSel, value);
        }
        
        public NFloat LineWidth
        {
            get => objc_msgSend_retNFloat(this, LineWidthProp.GetSel);
            set => objc_msgSend(this, LineWidthProp.SetSel, value);
        }

        public CAShapeLayerFillRule FillRule
        {
            get => throw new NotImplementedException();
            set => objc_msgSend(this, FillRuleProp.SetSel, value);
        }

        public CAShapeLayerLineCap LineCap
        {
            get => throw new NotImplementedException();
            set => objc_msgSend(this, LineCapProp.SetSel, value);
        }

        public CAShapeLayerLineJoin LineJoin
        {
            get => throw new NotImplementedException();
            set => objc_msgSend(this, LineJoinProp.SetSel, value);
        }

        public NFloat MiterLimit
        {
            get => objc_msgSend_retNFloat(this, MiterLimitProp.GetSel);
            set => objc_msgSend(this, MiterLimitProp.SetSel, value);
        }

        public sealed class CAShapeLayerFillRule
        {
            public readonly nint Self;

            private CAShapeLayerFillRule(nint self)
            {
                this.Self = self;
            }

            public static readonly CAShapeLayerFillRule EvenOdd = new CAShapeLayerFillRule(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCAFillRuleEvenOdd")));

            public static readonly CAShapeLayerFillRule NonZero = new CAShapeLayerFillRule(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCAFillRuleNonZero")));

            public static implicit operator nint(CAShapeLayerFillRule fillRule) => fillRule.Self;
        }

        public sealed class CAShapeLayerLineCap
        {
            public readonly nint Self;

            private CAShapeLayerLineCap(nint self)
            {
                this.Self = self;
            }

            public static readonly CAShapeLayerLineCap Butt = new CAShapeLayerLineCap(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCALineCapButt")));

            public static readonly CAShapeLayerLineCap Round = new CAShapeLayerLineCap(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCALineCapRound")));

            public static readonly CAShapeLayerLineCap Square = new CAShapeLayerLineCap(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCALineCapSquare")));

            public static implicit operator nint(CAShapeLayerLineCap fillRule) => fillRule.Self;
        }

        public sealed class CAShapeLayerLineJoin
        {
            public readonly nint Self;

            private CAShapeLayerLineJoin(nint self)
            {
                this.Self = self;
            }

            public static readonly CAShapeLayerLineJoin Miter = new CAShapeLayerLineJoin(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCALineJoinMiter")));

            public static readonly CAShapeLayerLineJoin Round = new CAShapeLayerLineJoin(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCALineJoinRound")));

            public static readonly CAShapeLayerLineJoin Bevel = new CAShapeLayerLineJoin(Marshal.ReadIntPtr(NativeLibrary.GetExport(CoreAnimation.Library, "kCALineJoinBevel")));

            public static implicit operator nint(CAShapeLayerLineJoin fillRule) => fillRule.Self;
        }
    }
}
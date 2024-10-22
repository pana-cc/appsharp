using static AppSharp.Platform.MacOS.CoreFoundation;
using static AppSharp.Platform.MacOS.AppKit;
using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

public static partial class ObjC
{
    public struct Prop
    {
        public readonly Sel GetSel;
        public readonly Sel SetSel;

        public Prop(string get, string set)
        {
            this.GetSel = new Sel(get);
            this.SetSel = new Sel(set);
        }
    }
}
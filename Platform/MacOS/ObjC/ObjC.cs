using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AppSharp.Platform.MacOS;

/// <summary>
/// Objective-C Runtime.
/// Exposing functions from "/usr/lib/libobjc.A.dylib"
/// https://developer.apple.com/documentation/objectivec/objective-c_runtime
/// </summary>
public static partial class ObjC
{
    public const string LibObjCLib = "/usr/lib/libobjc.A.dylib";

    [DllImport(LibObjCLib, EntryPoint="objc_getClass")]
    public static extern nint objc_getClass(string name);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern nint objc_msgSend_retIntPtr(nint obj, nint sel);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern nint objc_msgSend_retIntPtr(nint obj, nint sel, nint id1);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint obj, nint sel);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint obj, nint sel, bool v1);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint obj, nint sel, nint id1);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern void objc_msgSend(nint obj, nint sel, int id1);

    [DllImport(LibObjCLib)]
    public static extern nint objc_getProtocol(string name);

    [DllImport(LibObjCLib)]
    public static extern bool class_addProtocol(nint objcclass, nint name);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern bool objc_msgSend_retBool(nint obj, nint sel);

    [DllImport(LibObjCLib, EntryPoint = "objc_msgSend")]
    public static extern bool objc_msgSend_retBool(nint obj, nint sel, int int1);

    [DllImport(LibObjCLib)]
    public static extern nint objc_allocateClassPair(nint superclass, nint name, int extrabytes);

    [DllImport(LibObjCLib)]
    public static extern nint sel_registerName(string cfstring);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool SelfSelId_RetBool_Callback(nint self, nint sel, nint sender);

    [DllImport(LibObjCLib, EntryPoint = "class_addMethod")]
    private static extern bool class_addMethod_retBool(nint objcclass, nint name, [MarshalAs(UnmanagedType.FunctionPtr)]SelfSelId_RetBool_Callback fun, [MarshalAs(UnmanagedType.LPStr)] string types);
}
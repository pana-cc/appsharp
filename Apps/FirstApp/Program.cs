using System.Diagnostics;
using static AppSharp.Platform.MacOS.AppKit;
using static AppSharp.Platform.MacOS.Foundation;
using static AppSharp.Platform.MacOS.ObjC;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using var _ = new NSAutoreleasePool();

var nsAppRef = NSApplication.SharedApplication;
if (nsAppRef == null)
{
    throw new Exception("NSApplication.SharedApplication returned null.");
}

bool activated = nsAppRef.SetActivationPolicy(0);
if (!activated)
{
    throw new Exception($"NSApplication {nsAppRef} setActivationPolicy:0 returned false.");
}

using var appDelegate = new AppDelegate();
// Not sure...
appDelegate.Autorelease();

nsAppRef.Delegate = appDelegate;
nsAppRef.Activate();

Console.WriteLine("Within autorelease pool...");

// Create an Objective-C Window...
using var nsWindow = new NSWindow("AppSharp FirstApp");
using var rootView = new NSTextField();
nsWindow.ContentView = rootView;

// Objective-C Runloop...
nsAppRef.Run();

public class AppDelegate : NSObject
{
    public static new readonly Class Class = NSObject.Class
        .Extend("AppDelegate")
        // .AddProtocol(NSApplicationDelegate) // TODO: NSApplicationDelegate can't seem to get the protocol
        .AddMethod("applicationShouldTerminate:", AppDelegate.applicationShouldTerminate);

    public AppDelegate(nint id, bool releaseOnDispose = true) : base(id, releaseOnDispose)
    {
    }

    public AppDelegate() : this(Class.New())
    {
    }

    public override NSObject Autorelease() => (AppDelegate)base.Autorelease();

    public static bool applicationShouldTerminate(nint self, nint sel, nint sender)
    {
        Debug.WriteLine("Objective-C applicationShouldTerminate:");
        return true;
    }
}

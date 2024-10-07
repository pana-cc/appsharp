using System.Diagnostics;
using static AppSharp.Platform.MacOS.CoreFoundation;

namespace AppSharp.Platform.MacOS;

public static partial class ObjC
{
    /// <summary>
    /// Abstracts C# interactions with an Objective-C reference counted instance.
    /// </summary>
    public abstract class Ref : IDisposable
    {
        protected bool ReleaseOnDispose { get; private set; }
        protected nint Id { get; private set; }

        protected Ref(nint id, bool releaseOnDispose = true)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Constructor {this} id null.");
            }

            this.Id = id;

            if (releaseOnDispose)
            {
                this.ReleaseOnDispose = releaseOnDispose;
            }
            else
            {
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            if (this.ReleaseOnDispose && this.Id != 0)
            {
                this.ReleaseOnDispose = false;
                CFRelease(this.Id);
                this.Id = 0;
            }

            GC.SuppressFinalize(this);
        }

        ~Ref()
        {
            if (this.ReleaseOnDispose)
            {
                Debug.WriteLine($"Instance of {this} is destroyed by GC and holding ObjC ref, track lifetime and dispose instead.");
                Dispose();
            }
        }

        public static implicit operator nint(Ref cls) => cls.Id;
    }
}
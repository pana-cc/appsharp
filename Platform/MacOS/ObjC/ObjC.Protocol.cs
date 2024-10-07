using static AppSharp.Platform.MacOS.CoreFoundation;

namespace AppSharp.Platform.MacOS;

public static partial class ObjC
{
    /// <summary>
    /// Abstracts operations on Objective-C Class object.
    /// </summary>
    public class Protocol
    {
        private bool init;
        private nint id;

        public Protocol(string name)
        {
            this.Name = name;
            this.id = 0;
            this.init = false;
        }

        public Protocol(string name, nint id)
        {
            if (id == 0)
            {
                throw new ObjCException($"Objective-C Protocol '{this.Name}' constructed with 0.");
            }
            
            this.Name = name;
            this.id = id;
            this.init = true;
        }

        public string Name { get; }

        public nint Id
        {
            get
            {
                if (!this.init)
                {
                    this.init = true;
                    this.id = objc_getProtocol(this.Name);

                    if (this.id == 0)
                    {
                        throw new ObjCException($"Objective-C objc_getProtocol for '{this.Name}' returned 0.");
                    }
                }

                return this.id;
            }
        }

        public static implicit operator nint(Protocol protocol) => protocol.Id;
    }
}
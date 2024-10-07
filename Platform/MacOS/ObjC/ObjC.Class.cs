using System.Runtime.InteropServices;
using static AppSharp.Platform.MacOS.CoreFoundation;

namespace AppSharp.Platform.MacOS;

public static partial class ObjC
{
    /// <summary>
    /// Abstracts operations on Objective-C Class object.
    /// </summary>
    public class Class
    {
        public static readonly Sel AllocSel = new Sel("alloc");
        public static readonly Sel InitSel = new Sel("init");

        private bool init;
        private nint id;

        public Class(string name)
        {
            this.Name = name;
            this.id = 0;
            this.init = false;
        }

        public Class(string name, nint id)
        {
            if (id == 0)
            {
                throw new ObjCException($"Objective-C Class '{this.Name}' constructed with 0.");
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
                    this.id = objc_getClass(this.Name);

                    if (this.id == 0)
                    {
                        throw new ObjCException($"Objective-C objc_getClass for '{this.Name}' returned 0.");
                    }
                }

                return this.id;
            }
        }

        public nint New()
        {
            id = this.Alloc();

            id = objc_msgSend_retIntPtr(id, InitSel);
            if (id == 0)
            {
                throw new ObjCException($"Objective-C {this.Name} init returned 0.");
            }

            return id;
        }

        public nint Alloc()
        {
            nint id = objc_msgSend_retIntPtr(this, AllocSel);
            if (id == 0)
            {
                throw new ObjCException($"Objective-C {this.Name} alloc returned 0.");
            }

            return id;
        }

        /// <summary>
        /// Creates a runtime derived class.
        /// Under the hood calls into objc_allocateClassPair
        /// https://developer.apple.com/documentation/objectivec/1418559-objc_allocateclasspair?language=objc
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Class Extend(string name, int extraBytes = 0)
        {
            nint classNameCFString = CFString(name);
            nint derivedClass = objc_allocateClassPair(this, classNameCFString, extraBytes);
            if (derivedClass == 0)
            {
                throw new ObjCException($"Objective-C allocating derived class '{name}' from class '{this.Name}' returned 0.");
            }

            CFRelease(classNameCFString);
            return new Class(name, derivedClass);
        }

        public Class AddProtocol(Protocol protocol)
        {
            if (!class_addProtocol(this, protocol))
            {
                throw new ObjCException($"Objective-C '{this.Name}' class_addProtocol '{protocol.Name}' failed.");
            }

            return this;
        }

        public Class AddMethod(string selector, SelfSelId_RetBool_Callback applicationShouldTerminate)
        {
            nint objCSelector = sel_registerName(selector);
            if (objCSelector == 0)
            {
                throw new ObjCException($"Objective-C sel_registerName for '{selector}' returned 0.");
            }

            if (!class_addMethod_retBool(this, objCSelector, applicationShouldTerminate, "@:@"))
            {
                throw new ObjCException($"Objective-C class_addMethod_retBool for '{selector}' returned 0.");
            }

            return this;
        }

        public static implicit operator nint(Class cls) => cls.Id;
    }
}
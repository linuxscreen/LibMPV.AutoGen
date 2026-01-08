using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibMPVSharp
{
    public static class LibraryName
    {
        public const string Name = "libmpv";

        public static string WindowsLibrary { get; set; } = "libmpv-2";
        public static string LinuxLibrary { get; set; } = "libmpv.so";
        public static string AndroidLibrary { get; set; } = "libmpv.so";
        public static string MacLibrary { get; set; } = "libmpv.2.dylib";

        internal static void DllImportResolver()
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
        }
        

        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        { 
            var baseDir = AppContext.BaseDirectory;
            if (libraryName == Name)
            {
                if (OperatingSystem.IsWindows())
                {
                    // return NativeLibrary.Load(WindowsLibrary, assembly, searchPath);
                    return NativeLibrary.Load(System.IO.Path.Combine(baseDir, "runtimes", "win-x64", "native", WindowsLibrary));
                }
                else if (OperatingSystem.IsMacOS() || OperatingSystem.IsMacCatalyst())
                {
                    return NativeLibrary.Load(System.IO.Path.Combine(baseDir, "runtimes", "osx", "native", MacLibrary));
                    // return NativeLibrary.Load(MacLibrary, assembly, searchPath);
                }
                else if (OperatingSystem.IsAndroid())
                {
                    return NativeLibrary.Load(AndroidLibrary, assembly, searchPath);
                }
                else if  (OperatingSystem.IsLinux())
                {
                    // return NativeLibrary.Load(LinuxLibrary, assembly, searchPath);
                    return NativeLibrary.Load(System.IO.Path.Combine(baseDir, "runtimes", "linux-x64", "native", LinuxLibrary));
                }
            }
            return IntPtr.Zero;
        }
    }
}

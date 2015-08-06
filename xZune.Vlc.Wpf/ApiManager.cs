using System;

namespace xZune.Vlc.Wpf
{
    public static class ApiManager
    {
        static ApiManager()
        {
            IsInitialized = false;
            LibVlcPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\LibVlc\";
        }

        #region LibVlcPath
        public static String LibVlcPath { get; set; }
        #endregion

        #region VlcOption
        public static String[] VlcOption { get; set; }
        #endregion

        #region Vlc
        public static Vlc Vlc { get; private set; }
        #endregion

        #region IsInited
        public static bool IsInitialized { get; private set; }
        #endregion

        public static void Initialize()
        {
            if (IsInitialized) return;
            Vlc.LoadLibVlc(LibVlcPath);
            Vlc = new Vlc(VlcOption);
        }

        public static void Initialize(String libVlcPath)
        {
            LibVlcPath = libVlcPath;
            Initialize();
        }

        public static void Initialize(String libVlcPath, String[] vlcOption)
        {
            LibVlcPath = libVlcPath;
            VlcOption = vlcOption;
            Initialize();
        }

        public static void ReleaseAll()
        {
            if(Vlc != null)
            Vlc.Dispose();
        }
    }
}

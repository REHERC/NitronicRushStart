using Spectrum.API.Experimental;
using Spectrum.API.Storage;

namespace NitronicRushStart
{
    public static class CurrentPlugin
    {
        public static Assets NitronicHUD;

        public static void Initialize()
        {
            NitronicHUD = new Assets("nitronichud");
        }

        public static string PluginDataPath()
        {
            return new FileSystem().RootDirectory + @"\Data";
        }
    }
}
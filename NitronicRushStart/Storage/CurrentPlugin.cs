using Spectrum.API.Experimental;
using Spectrum.API.Storage;

namespace NitronicRushStart
{
    public static class CurrentPlugin
    {
        public static Assets Assets;

        public static void Initialize()
        {
            Assets = new Assets("nitronichud");
        }

        public static string PluginDataPath()
        {
            return new FileSystem().RootDirectory + @"\Data";
        }
    }
}
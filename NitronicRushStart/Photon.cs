using System;
using System.Reflection;
using Harmony;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using Spectrum.API.Logging;

namespace NitronicRushStart
{
    public partial class Photon : IPlugin
    {
        public void Initialize(IManager manager, string ipcIdentifier)
        {
            try
            {
                CurrentPlugin.Initialize();
                SharedAudio.Init();

                HarmonyInstance Harmony = HarmonyInstance.Create("com.REHERC.NitronicRushStart");
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Logger log = new Logger("NRStart.log");
                log.WriteToConsole = true;
                log.Exception(e);
            }

            Events.Scene.StartLoad.Subscribe((data) =>
            {
                SharedAudio.Reset();
            });

            Events.GameMode.ModeStarted.Subscribe((data) =>
            {
                SharedAudio.Reset();
            });
        }
    }
}
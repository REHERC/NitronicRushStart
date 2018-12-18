using System;
using System.Reflection;
using Harmony;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;

namespace NitronicRushStart
{
    public partial class Photon : IPlugin
    {
        public void Initialize(IManager manager, string ipcIdentifier)
        {
            // Patch existing classes
            try
            {
                CurrentPlugin.Initialize();
                SharedAudio.Init();

                HarmonyInstance Harmony = HarmonyInstance.Create("com.REHERC.NitronicRushStart");
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {

            }

            // Subscribe to events
            Events.Scene.StartLoad.Subscribe((data) =>
            {
                SharedAudio.Reset();
            });

            Events.GameMode.ModeStarted.Subscribe((data) =>
            {
                SharedAudio.Reset();
            });
        }

        //public void Update()
        //{
        //   
        //}
    }
}
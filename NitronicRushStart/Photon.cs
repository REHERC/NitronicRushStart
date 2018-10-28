using System;
using System.Reflection;
using Harmony;
using NitronicRushStart.UnityScripts;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NitronicRushStart
{
    public partial class Photon : IPlugin , IUpdatable
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
                Spectrum.API.Logging.Logger log = new Spectrum.API.Logging.Logger("NRStart.log");
                log.WriteToConsole = true;
                log.Exception(e);
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

        public void Update()
        {
            GameObject HUD = GameObject.Find("NitronicCountdownHUD");
            Console.Title = Timex.ModeTime_.ToString();

            if (HUD != null)
            {
                CountdownManager manager = HUD.GetComponent<CountdownManager>();
                
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name != "MainMenu" && scene.name != "LevelEditor" && G.Sys.GameManager_.ModeID_ != GameModeID.Adventure && G.Sys.GameManager_.ModeID_ != GameModeID.LostToEchoes)
                {
                    manager.Time = Convert.ToSingle(Timex.ModeTime_);
                    if (Convert.ToSingle(Timex.ModeTime_) > 5)
                    {
                        HUD.Destroy();
                    }
                }
                else
                {
                    HUD.Destroy();
                }
            }
        }
    }
}
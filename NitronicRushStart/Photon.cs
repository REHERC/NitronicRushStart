using System;
using System.Collections.Generic;
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
                CreateAudioManager();
            });
            
            /*
            Events.GameMode.ModeStarted.Subscribe((data) =>
            {
                
            });
            */
        }

        public static GameObject AM_Obj;
        public static UnityScripts.AudioManager AM;
        public static AudioListener AM_Listener;

        public void CreateAudioManager()
        {
            if (AM_Obj == null)
            {
                string AssetName = "Assets/Prefabs/AudioManager.prefab";
                GameObject Prefab = CurrentPlugin.Assets.Bundle.LoadAsset<GameObject>(AssetName);
                AM_Obj = GameObject.Instantiate(Prefab);
                AM_Obj.name = "AudioManager";
                AM_Obj.transform.parent = null;
                AM = AM_Obj.AddComponent(typeof (UnityScripts.AudioManager)) as UnityScripts.AudioManager;
                AM_Listener = AM_Obj.AddComponent(typeof(AudioListener)) as AudioListener;
                AM.Sounds = new List<UnityScripts.Sound>();
                AM.Sounds.Add(new UnityScripts.Sound("Countdown3", "Assets/Audio/3.wav"));
                AM.Sounds.Add(new UnityScripts.Sound("Countdown2", "Assets/Audio/2.wav"));
                AM.Sounds.Add(new UnityScripts.Sound("Countdown1", "Assets/Audio/1.wav"));
                AM.Sounds.Add(new UnityScripts.Sound("CountdownRush", "Assets/Audio/rush.wav"));
                AM.Setup();

                UnityEngine.Object.DontDestroyOnLoad(AM_Obj);
                UnityEngine.Object.DontDestroyOnLoad(AM);
            }
            
        }

        public void Update()
        {
            GameObject HUD = GameObject.Find("NitronicCountdownHUD");
            Console.Title = (GameObject.Find(AM_Obj?.name) != null).ToString() + " | " + UnityEngine.Object.FindObjectsOfType<Camera>().Length + " camera(s) | " + UnityEngine.Object.FindObjectsOfType<AudioListener>().Length + " audio listener(s)";

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
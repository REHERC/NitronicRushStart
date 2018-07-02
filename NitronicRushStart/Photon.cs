using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Events.MainMenu;
using Harmony;
using Spectrum.API;
using Spectrum.API.Configuration;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using Spectrum.API.IPC;
using Spectrum.API.Logging;
using UnityEngine;

namespace NitronicRushStart
{
    public partial class Photon : IPlugin
    {
        public void Initialize(IManager manager, string ipcIdentifier)
        {
            Console.WriteLine("Initializing ...");
            CurrentPlugin.Initialize();
            CurrentPlugin.Log.Info("Initialization done!");
            try
            {
                CurrentPlugin.Log.Info("Subscribing to events ...");
                Events.GameMode.ModeStarted.Subscribe(LevelLoaded);
                Events.MainMenu.Initialized.Subscribe(MainMenuLoaded);
                CurrentPlugin.Log.Info("Subscribed to events!");
            }
            catch (Exception VirusSpirit)
            {
                CurrentPlugin.Log.Error("Failed to patch the assemblies!");
                CurrentPlugin.Log.Exception(VirusSpirit);
            }
        }
        
        private string LevelName = "";
        private string LastLevelName = "";

        public void LevelLoaded(Events.GameMode.ModeStarted.Data data)
        {
            LevelName = Spectrum.Interop.Game.Game.LevelName;
            bool isRestarted = (bool)(LevelName == LastLevelName);
            LastLevelName = LevelName;
            if (!(Spectrum.Interop.Game.Game.CurrentMode == Spectrum.Interop.Game.GameMode.None || Spectrum.Interop.Game.Game.CurrentMode == Spectrum.Interop.Game.GameMode.LevelEditorTest))
            {
                CurrentPlugin.NITRONIC.PlayNRStart(isRestarted);
            }
            else
            {
                LevelName = "";
                LastLevelName = "";
            }
        }
        private void MainMenuLoaded(Initialized.Data data)
        {
            LevelName = "";
            LastLevelName = "";
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.API.Configuration;
using Spectrum.API.Logging;
using Spectrum.API.Storage;
using UnityEngine;
using NAudio;
using NAudio.Wave;
using System.Threading;

namespace NitronicRushStart
{
    public static class CurrentPlugin
    {
        public static NRStart NITRONIC;
        public static Spectrum.API.Logging.Logger Log;
        public static Settings Config;
        public static FileSystem Files;

        public static string ActivationMode;
        public static bool DisableInAdventure;

        public static void Initialize()
        {
            Log = new Spectrum.API.Logging.Logger("NitronicRushStart.log");
            Log.WriteToConsole = true;
            Files = new FileSystem();
            NITRONIC = new NitronicRushStart.NRStart();
            Config = new Settings("Config");

            ActivationMode = Config.GetItem<string>("EnableMode");
            DisableInAdventure = Config.GetItem<bool>("DisableInAdventure");
        }
    }
}
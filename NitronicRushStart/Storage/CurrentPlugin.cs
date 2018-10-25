using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static string PluginDataPath()
        {
            return new FileSystem().RootDirectory + @"\Data";
        }
    }
}
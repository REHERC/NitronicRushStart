using System;
using System.IO;
using UnityEngine;

namespace NitronicRushStart.UnityScripts
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public Stream Clip;
        [Range(0.0f,1.0f)]
        public float Volume = 1;

        public Sound(string name, string path)
        {
            try
            {
                this.Name = name;
                this.Clip = new FileStream(CurrentPlugin.PluginDataPath() + path, FileMode.Open);
                this.Volume = 1;
            }
            catch (Exception e)
            {
                Spectrum.API.Logging.Logger log = new Spectrum.API.Logging.Logger("NRStart.log");
                log.WriteToConsole = true;
                log.Exception(e);
            }
        }
    }
}

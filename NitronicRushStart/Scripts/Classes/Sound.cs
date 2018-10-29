using System;
using UnityEngine;

namespace NitronicRushStart.UnityScripts
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        [Range(0.0f,1.0f)]
        public float Volume = 1;
        [HideInInspector]
        public AudioSource Source;

        public Sound(string name, string bundlepath)
        {
            try
            {
                this.Name = name;
                this.Clip = CurrentPlugin.Assets.Bundle.LoadAsset<AudioClip>(bundlepath);
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

using System;
using System.Collections.Generic;
using System.IO;
using CSCore;
using CSCore.Codecs.MP3;
using CSCore.SoundOut;
using UnityEngine;

namespace NitronicRushStart.UnityScripts
{
    public class AudioManager : MonoBehaviour
    {
        public List<Sound> Sounds;
        
        public void Setup()
        {
            UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
            Console.WriteLine("Loaded sounds :");
            foreach (Sound CurrentSound in Sounds)
            {
                Console.WriteLine($"  {CurrentSound.Name}");
            }
        }

        public void Play(string name)
        {
            Sound s = Sounds.Find(x => x.Name == name);
            if (s == null || s.Clip == null)
            {
                Console.WriteLine($@"Sound {name} not found");
                return;
            }
            
            using (IWaveSource soundSource = GetSoundSource(s.Clip))
            {
                ISoundOut soundOut = GetSoundOut();
                soundOut.Initialize(soundSource);
                soundOut.Volume = 1; // s.Volume * G.Sys.OptionsManager_.Audio_.AnnouncerVolume_ * G.Sys.OptionsManager_.Audio_.MasterVolume_;
                soundOut.Play();
            }
        }

        private ISoundOut GetSoundOut()
        {
            if (WasapiOut.IsSupportedOnCurrentPlatform)
                return new WasapiOut();
            else
                return new DirectSoundOut();
        }

        private IWaveSource GetSoundSource(Stream stream)
        {
            return new DmoMp3Decoder(stream);

        }

        public void Destruct()
        {
            foreach (Sound CurrentSound in Sounds)
            {
                CurrentSound.Clip.Dispose();
            }
        }
    }
}

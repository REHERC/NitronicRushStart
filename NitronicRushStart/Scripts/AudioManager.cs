using System;
using System.Collections.Generic;
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
                CurrentSound.Source = this.gameObject.AddComponent<AudioSource>();
                CurrentSound.Source.clip = CurrentSound.Clip;
                CurrentSound.Source.spatialBlend = 0;
            }
        }

        public void Play(string name)
        {
            Sound s = Sounds.Find(x => x.Name == name);
            if (s == null)
            {
                Console.WriteLine($@"Sound {name} not found");
                return;
            }
            s.Source.volume = 100; //G.Sys.OptionsManager_.Audio_.AnnouncerVolume_;
            s.Source.Play();
        }
    }
}

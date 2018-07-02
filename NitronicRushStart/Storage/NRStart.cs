using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using UnityEngine;

namespace NitronicRushStart
{
    public class NRStart : MonoBehaviour
    {
        private WaveOutEvent WaveOut;
        private WaveFileReader File;
        
        private void InitAudio(bool restarted)
        {
            WaveOut = new WaveOutEvent();
            if (restarted)
            {
                File = new WaveFileReader(CurrentPlugin.Files.RootDirectory + "\\Data\\NitronicRushStartInstant.wav");
            }
            else
            {
                File = new WaveFileReader(CurrentPlugin.Files.RootDirectory + "\\Data\\NitronicRushStartDelayed.wav");
            }
            
            WaveOut.Init(File);
        }

        public void PlayNRStart(bool restarted)
        {
            switch (CurrentPlugin.ActivationMode)
            {
                case "Always":
                    ActuallyPlaySound();
                    break;
                case "Never":
                    return;
            }
            InitAudio(restarted);
            WaveOut.Stop();
            //WaveOut.Volume = G.Sys.OptionsManager_.Audio_.AnnouncerVolume_;
            WaveOut.Play();
        }

        private void ActuallyPlaySound()
        {

        }
    }
}

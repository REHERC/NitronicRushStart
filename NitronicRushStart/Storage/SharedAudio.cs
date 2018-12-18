using NAudio.Wave;

namespace NitronicRushStart
{
    public static class SharedAudio
    {
        public static WaveOut Countdown_3;
        public static WaveOut Countdown_2;
        public static WaveOut Countdown_1;
        public static WaveOut Countdown_Rush;


        public static void Init()
        {
            Countdown_3 = new WaveOut();
            Countdown_2 = new WaveOut();
            Countdown_1 = new WaveOut();
            Countdown_Rush = new WaveOut();

            Reset();
        }

        public static void SetVolume(float volume)
        {
            Countdown_3.Volume = volume;
            Countdown_2.Volume = volume;
            Countdown_1.Volume = volume;
            Countdown_Rush.Volume = volume;
        }

        public static void Reset()
        {
            Countdown_3.Stop();
            Countdown_2.Stop();
            Countdown_1.Stop();
            Countdown_Rush.Stop();

            string Data = CurrentPlugin.PluginDataPath();

            Countdown_3.Init(new WaveFileReader($@"{Data}\Audio\3.wav"));
            Countdown_2.Init(new WaveFileReader($@"{Data}\Audio\2.wav"));
            Countdown_1.Init(new WaveFileReader($@"{Data}\Audio\1.wav"));
            Countdown_Rush.Init(new WaveFileReader($@"{Data}\Audio\rush.wav"));
        }
    }
}
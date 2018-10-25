using System;
using Harmony;

namespace NitronicRushStart
{
    [HarmonyPatch(typeof(Phantom))]
    [HarmonyPatch("Play")]
    class Phantom__Play__Patch
    {

        static void Postfix(Phantom __instance, ref string name)
        {
            try
            {
                switch (name.ToLowerInvariant())
                {
                    case "startbeep3":
                        SharedAudio.Countdown_1.Play();
                        break;
                    case "startbeep2":
                        SharedAudio.Countdown_2.Play();
                        break;
                    case "startbeep1":
                        SharedAudio.Countdown_3.Play();
                        break;
                    case "startbeepgo":
                        SharedAudio.Countdown_Rush.Play();
                        break;
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}

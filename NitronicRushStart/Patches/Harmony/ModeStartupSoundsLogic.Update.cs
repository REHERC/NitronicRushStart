using System;
using Harmony;

namespace NitronicRushStart
{
    // For some reason, using this makes the announcer say rush as soon as the map loads :/
    //[HarmonyPatch(typeof (ModeStartupSoundsLogic), "Update")]
    internal class ModeStartupSoundsLogic__Update__Patch
    {
        static void Prefix(ModeStartupSoundsLogic __instance, int __state)
        {
            if (__instance.countDown_)
            {
                __state = __instance.GetPrivateField<int>("display_");
            }
            else
            {
                __state = 0;
            }
        }

        static void Postfix(ModeStartupSoundsLogic __instance, int __state)
        {
            int currentDisplay = __instance.GetPrivateField<int>("display_");

            if (currentDisplay < __state)
            {
                switch (__state) {
                    case 3:
                        SharedAudio.Countdown_3.Play();
                        Console.WriteLine("3");
                        break;
                    case 2:
                        SharedAudio.Countdown_2.Play();
                        Console.WriteLine("2");
                        break;
                    case 1:
                        SharedAudio.Countdown_1.Play();
                        Console.WriteLine("1");
                        break;
                    case 0:
                        SharedAudio.Countdown_Rush.Play();
                        Console.WriteLine("RUSH !!!");
                        break;
                }

            }
        }
    }
}

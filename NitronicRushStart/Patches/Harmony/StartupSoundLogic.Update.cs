using System;
using Harmony;

namespace NitronicRushStart
{
    //[HarmonyPatch(typeof (ModeStartupSoundsLogic), "Update")]
    internal class ModeStartupSoundsLogic__Update__Patch
    {

        static void Postfix(ModeStartupSoundsLogic __instance)
        {
            //__instance.countDown_ = false;
        }
    }
}
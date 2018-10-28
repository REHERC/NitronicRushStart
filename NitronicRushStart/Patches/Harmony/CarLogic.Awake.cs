using System;
using Harmony;
using NitronicRushStart.UnityScripts;
using UnityEngine;

namespace NitronicRushStart
{
    [HarmonyPatch(typeof(CarLogic), "Awake")]
    internal class CarLogic__Awake__Patch
    {
        static void Postfix(CarLogic __instance)
        {
            try
            {
                string AssetName = "Assets/Prefabs/NitronicCountdownHUD.prefab";
                GameObject Prefab = CurrentPlugin.NitronicHUD.Bundle.LoadAsset<GameObject>(AssetName);
                GameObject HUD = GameObject.Instantiate(Prefab);
                HUD.name = "NitronicCountdownHUD";
                
                Countdown NR_3 = HUD.transform.FindChild("NR-3").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_3.StartKey = -3.5f;
                NR_3.DurationKey = 0.75f;
                
                Countdown NR_2 = HUD.transform.FindChild("NR-2").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_2.StartKey = -2.5f;
                NR_2.DurationKey = 0.75f;
                
                Countdown NR_1 = HUD.transform.FindChild("NR-1").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_1.StartKey = -1.5f;
                NR_1.DurationKey = 0.75f;
                
                Countdown NR_R = HUD.transform.FindChild("NR-Rush").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_R.StartKey = -0.5f;
                NR_R.DurationKey = 1.0f;
                
                CountdownManager Manager = HUD.AddComponent(typeof(CountdownManager)) as CountdownManager;
                Manager.Setup();
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

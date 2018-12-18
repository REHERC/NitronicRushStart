﻿using System;
using Harmony;
using NitronicRushStart.UnityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                GameObject Prefab = CurrentPlugin.Assets.Bundle.LoadAsset<GameObject>(AssetName);
                GameObject HUD = GameObject.Instantiate(Prefab);
                HUD.name = "NitronicCountdownHUD";
                
                Countdown NR_3 = HUD.transform.FindChild("NR-3").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_3.StartKey = -3.5f;
                NR_3.DurationKey = 0.75f;
                NR_3.AudioClipStart = -3.0f;
                NR_3.AudioClipName = "Countdown3";
                
                Countdown NR_2 = HUD.transform.FindChild("NR-2").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_2.StartKey = -2.5f;
                NR_2.DurationKey = 0.75f;
                NR_2.AudioClipStart = -2.0f;
                NR_2.AudioClipName = "Countdown2";

                Countdown NR_1 = HUD.transform.FindChild("NR-1").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_1.StartKey = -1.5f;
                NR_1.DurationKey = 0.75f;
                NR_1.AudioClipStart = -1.0f;
                NR_1.AudioClipName = "Countdown1";

                Countdown NR_R = HUD.transform.FindChild("NR-Rush").gameObject.AddComponent(typeof(Countdown)) as Countdown;
                NR_R.StartKey = -0.5f;
                NR_R.DurationKey = 1.0f;
                NR_R.AudioClipStart = 0.0f;
                NR_R.AudioClipName = "CountdownRush";

                CountdownManager Manager = HUD.AddComponent(typeof(CountdownManager)) as CountdownManager;
                Manager.Setup();

                Scene scene = SceneManager.GetActiveScene();
                if (scene.name != "MainMenu" && scene.name != "LevelEditor" && G.Sys.GameManager_.ModeID_ != GameModeID.Adventure && G.Sys.GameManager_.ModeID_ != GameModeID.LostToEchoes)
                {
                    __instance.gameObject.AddComponent<UnityScripts.GameUpdate>();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}

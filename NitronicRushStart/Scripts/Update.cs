using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NitronicRushStart.UnityScripts
{
    class GameUpdate : MonoBehaviour
    {
        void Update()
        {
            GameObject HUD = GameObject.Find("NitronicCountdownHUD");

            if (HUD != null)
            {
                CountdownManager manager = HUD.GetComponent<CountdownManager>();

                Scene scene = SceneManager.GetActiveScene();
                if (scene.name != "MainMenu" && scene.name != "LevelEditor" && G.Sys.GameManager_.ModeID_ != GameModeID.Adventure && G.Sys.GameManager_.ModeID_ != GameModeID.LostToEchoes)
                {
                    manager.Time = Convert.ToSingle(Timex.ModeTime_);
                    if (Convert.ToSingle(Timex.ModeTime_) > 5)
                    {
                        HUD.gameObject.Destroy();
                    }
                }
                else
                {
                    HUD.gameObject.Destroy();
                }
            }
        }
    }
}
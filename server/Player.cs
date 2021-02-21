using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValheimSharedMap;
using HarmonyLib;
using System.Globalization;
using Steamworks;

namespace ValheimSharedMap
{
    [HarmonyPatch(typeof(Player), "OnSpawned")]
    public static class ModifyOnSpawned
    {
        private static void Prefix()
        {

            Tutorial.TutorialText introTutorial = new Tutorial.TutorialText()
            {
                m_label = "Shared Map Intro",
                m_name = "smap",
                m_text = "This mod enables you to share your map with other players!",
                m_topic = "Welcome to MapShare"
            };

            if (!Tutorial.instance.m_texts.Contains(introTutorial))
            {
                Tutorial.instance.m_texts.Add(introTutorial);
            }

            Player.m_localPlayer.ShowTutorial("smap");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using Unity;
using UnityEngine;
using System.IO;
using System.Reflection;
using System.Runtime;
using HarmonyLib;
using System.Globalization;
using Steamworks;
using ValheimSharedMap;

namespace ValheimSharedMap
{
    class VersionInfo
    {

        [HarmonyPatch(typeof(Console), "Awake")]
        public static class HookConsole
        {
            private static void Postfix(ref Console __instance)
            {
                __instance.Print("ValheimSharedMap [v0.1] is loaded.");
            }

        }

        [HarmonyPatch(typeof(FejdStartup), "SetupGui")]
        public static class HookGui
        {
            private static void Postfix(ref FejdStartup __instance)
            {
                __instance.m_versionLabel.fontSize = 14;
                //string gameVersion = Version.CombineVersion(global::Version.m_major, global::Version.m_minor, global::Version.m_patch);
                //__instance.m_versionLabel.text = "version " + gameVersion + "\n" + "ValheimSharedMap v0.1";
                __instance.m_versionLabel.text = "version 0.145.6\n" + "ValheimSharedMap v0.1";
            }

        }
    }
}

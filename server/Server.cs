using System;
using System.IO;
using System.Text;
using ValheimSharedMap;
using Unity;
using UnityEngine;
using HarmonyLib;
using System.Globalization;
using Steamworks;
using BepInEx;

namespace ValheimSharedMap
{
    [HarmonyPatch(typeof(ZNet), "Awake")]
    public static class ChangeGameServerVariables
    {
        private static void Postfix(ref ZNet __instance)
        {
            // Set Server Instance Max Players
            __instance.m_serverPlayerLimit = 84;
        }

    }

    [HarmonyPatch(typeof(ZNet), "Shutdown")]
    public static class DebugOutputShutdown
    {
        private static void Postfix(ref ZNet __instance)
        {
            using (StreamWriter w = File.AppendText("C:\\tmp\\log.txt"))
            {
                Log("**** Server is shutting down ****", w);
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }
    }
}

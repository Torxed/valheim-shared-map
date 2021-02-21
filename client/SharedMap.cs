using System;
using System.IO;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using Steamworks;
using HarmonyLib;
using System.Globalization;
using BepInEx;

namespace ValheimSharedMap {
    [BepInPlugin("org.bepinex.plugins.valheim_shared_map", "Valheim Shared Map", "0.1")]
    public class ValheimSharedMap : BaseUnityPlugin
    {
        void Awake()
        {
            // Logger comes from UnityEngine.core
            Logger.LogInfo("Trying to load the shared map configuration");
            var harmony = new Harmony("mod.valheim_shared_map");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Minimap))]
    public class hookExplore
    {
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(Minimap), "Explore", new Type[] { typeof(Vector3), typeof(float) })]
        public static void call_Explore(object instance, Vector3 p, float radius) => throw new NotImplementedException();
    }
    [HarmonyPatch(typeof(ZNet))]
    public class hookZNet
    {
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(ZNet), "GetOtherPublicPlayers", new Type[] { typeof(List<ZNet.PlayerInfo>) })]
        public static void GetOtherPublicPlayers(object instance, List<ZNet.PlayerInfo> playerList) => throw new NotImplementedException();

    }

    [HarmonyPatch(typeof(Minimap), "UpdateExplore")]
    public static class ChangeMapBehavior
    {

        private static void Prefix(ref float dt, ref Player player, ref Minimap __instance, ref float ___m_exploreTimer, ref float ___m_exploreInterval, ref List<ZNet.PlayerInfo> ___m_tempPlayerInfo) // Set after awake function
        {

            float exploreRadius = 100;
            //float explorerTime = ___m_exploreTimer;
            //explorerTime += Time.deltaTime;
            //if (explorerTime > ___m_exploreInterval)
            //{
            ___m_tempPlayerInfo.Clear();
            hookZNet.GetOtherPublicPlayers(ZNet.instance, ___m_tempPlayerInfo); // inconsistent returns but works

            if (___m_tempPlayerInfo.Count > 0)
            {
                foreach (ZNet.PlayerInfo m_Player in ___m_tempPlayerInfo)
                {
                    hookExplore.call_Explore(__instance, m_Player.m_position, exploreRadius);
                }
            }

            //}
            // Always reveal for your own, we do this non the less to apply the potentially bigger exploreRadius
            hookExplore.call_Explore(__instance, player.transform.position, exploreRadius);
        }
    }
}
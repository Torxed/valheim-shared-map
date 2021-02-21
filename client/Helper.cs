﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValheimSharedMap;
using HarmonyLib;
using System.Globalization;
using Steamworks;

namespace ValheimSharedMap
{
    static class Helper
    {
        public static Character getPlayerCharacter(Player __instance)
        {
            return (Character)__instance;
        }

        public static float tFloat(this float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }
    }
}

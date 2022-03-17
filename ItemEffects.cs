// BenjimsEndgameArmor
// a Valheim mod skeleton using Jötunn
// 
// File:    BenjimsEndgameArmor.cs
// Project: BenjimsEndgameArmor

using HarmonyLib;
using System;

namespace BenjimsEndgameArmor
{
    internal partial class BenjimsEndgameArmor
    {
        [HarmonyPatch]
        public class ItemEffects
        {
            // this provides wet immunity for the Frostscale Hauberk
            [HarmonyPatch("Player, assembly_valheim", "UpdateEnvStatusEffects"), HarmonyPostfix]
            public static void WetPatch(ref SEMan ___m_seman, ItemDrop.ItemData ___m_chestItem)
            {
                if (___m_chestItem == null)
                {
                    return;
                }
                if (___m_chestItem.m_shared.m_name == "Frostscale Hauberk")
                {
                    /* Adding true here helps reduce status message spam; if we don't do this the
                     * spam persists long after getting out of the water because of how it alternates
                     * between becoming wet and becoming dry.  This way, you get spammed with Wet while
                     * in the water, but it promptly fades on getting out.
                     */
                    ___m_seman.RemoveStatusEffect("Wet", true);
                }
            }

            // this provides swim skill for the Frostscale Boots
            [HarmonyPatch("Skills, assembly_valheim", "GetSkillFactor"), HarmonyPostfix]
            public static float SwimSkillPatch(float __result, Player ___m_player, Skills.SkillType skillType)
            {
                if(skillType != Skills.SkillType.Swim || ___m_player.m_legItem == null)
                {
                    return __result;
                }
                else if (___m_player.m_legItem.m_shared.m_name != "Frostscale Boots")
                {
                    return __result;
                }
                else
                {
                    return Math.Min(__result + 0.5F, 1f);
                }
            }

            // gives swim speed for Frostscale Boots
            // original code does have this spelling error in the method name
            [HarmonyPatch("Player, assembly_valheim", "OnSwiming"), HarmonyPostfix]
            public static void SwimSpeedPatch(ref float ___m_swimSpeed, ref float ___m_swimAcceleration, ItemDrop.ItemData ___m_legItem)
            {
                if (___m_legItem == null)
                {
                    // default values
                    ___m_swimSpeed = 2f;
                    ___m_swimAcceleration = 0.05f;
                }
                else if (___m_legItem.m_shared.m_name != "Frostscale Boots")
                {
                    // default values
                    ___m_swimSpeed = 2f;
                    ___m_swimAcceleration = 0.05f;
                }
                else
                {
                    // you're a fish!
                    ___m_swimSpeed = 6f;
                    ___m_swimAcceleration = 0.15f;
                }
            }
        }
    }
}


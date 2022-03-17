// BenjimsEndgameArmor
// a Valheim mod skeleton using Jötunn
// 
// File:    BenjimsEndgameArmor.cs
// Project: BenjimsEndgameArmor

using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BenjimsEndgameArmor
{
    internal partial class BenjimsEndgameArmor
    {
        /* We want to add some custom drops to the Deep North custom monsters.  Monsternomicon uses RRR 
         * which loads well after JVL is done, so we have to hook a postfix once the Monsters are in the game.
         * Thanks to Margmas on the JVL subreddit for suggesting this hook point and showing me how to reference
         * it with Harmony!
         */
        [HarmonyPatch]
        public class MonsternomiconDropPatches
        {
            // format of this line is "MainClassInsideDLL.ClassToPatch, DLLName", "MethodToPatch"
            [HarmonyPatch("RRRCore.Plugin, RRRCore", "LateLoadServer"), HarmonyPostfix]
            public static void LateLoadServerPatch()
            {
                EditMonsternomiconDropTables();
            }

            [HarmonyPatch("RRRCore.Plugin, RRRCore", "LateLoadClient"), HarmonyPostfix]
            public static void LateLoadClientPatch()
            {
                EditMonsternomiconDropTables();
            }

            public static CharacterDrop.Drop MakeDrop(string prefabname, int min, int max, bool perplayer, float chance)
            {
                return new CharacterDrop.Drop
                {
                    m_prefab = ZNetScene.m_instance.GetPrefab(prefabname),
                    m_amountMin = min,
                    m_amountMax = max,
                    m_onePerPlayer = perplayer,
                    m_chance = chance
                };
            }
            private static void EditMonsternomiconDropTables()
            {
                try
                {
                    if (!ZNetScene.m_instance)
                    {
                        return;
                    }

                    // this will make sure we have the mobs loaded already
                    GameObject prefab = ZNetScene.m_instance.GetPrefab("RRRM_PolarLox");

                    if (!prefab)
                    {
                        return;
                    }

                    // Create new PolarLox drop 
                    var loxmeatdrop = MakeDrop("LoxMeat",2,4,false,1f);
                    var frozenpeltdrop = MakeDrop("FrozenPelt", 2, 4, false, 1f);
                    var loxtrophydrop = MakeDrop("TrophyLox", 1, 1, false, 0.5f);
                    var newloxdroplist = new List<CharacterDrop.Drop> { loxmeatdrop, frozenpeltdrop, loxtrophydrop };
                    ZNetScene.m_instance.GetPrefab("RRRM_PolarLox").GetComponent<CharacterDrop>().m_drops = newloxdroplist;

                    // Create new PolarFenring drop table
                    var fenringtoothdrop = MakeDrop("IcyFang", 2, 4, false, 1f);
                    var fenringtrophydrop = MakeDrop("TrophyFenring", 1, 1, false, 0.5f);
                    var newfenringdroplist = new List<CharacterDrop.Drop> { fenringtoothdrop, fenringtrophydrop };
                    ZNetScene.m_instance.GetPrefab("RRRM_PolarFenring").GetComponent<CharacterDrop>().m_drops = newfenringdroplist;

                    // Create new PolarSerpent drop table
                    var serpentmeatdrop = MakeDrop("SerpentMeat", 2, 4, false, 1f);
                    var polarscaledrop = MakeDrop("PolarScale", 2, 4, false, 1f);
                    var serpenttrophydrop = MakeDrop("TrophySerpent", 1, 1, false, 0.25f);
                    var newserpentdroplist = new List<CharacterDrop.Drop> { serpentmeatdrop, polarscaledrop, serpenttrophydrop };
                    ZNetScene.m_instance.GetPrefab("RRRM_SmallPolarSerpent").GetComponent<CharacterDrop>().m_drops = newserpentdroplist;

                    // Create new SilverGolem drop table
                    var golemcrystaldrop = MakeDrop("Crystal", 3, 6, false, 1f);
                    var golemicedrop = MakeDrop("PrimordialIce", 3, 6, false, 1f);
                    var golemtrophydrop = MakeDrop("TrophySGolem", 1, 1, false, 0.5f);
                    var newgolemdroplist = new List<CharacterDrop.Drop> { golemcrystaldrop, golemicedrop, golemtrophydrop };
                    ZNetScene.m_instance.GetPrefab("RRRM_SilverGolem").GetComponent<CharacterDrop>().m_drops = newgolemdroplist;
                }
                catch (Exception ex)
                {
                    Jotunn.Logger.LogWarning($"Exception caught while modifying drop tables: {ex}");
                }
            }
        }
    }
}


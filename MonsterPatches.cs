// BenjimsEndgameArmor
// a Valheim mod skeleton using Jötunn
// 
// File:    BenjimsEndgameArmor.cs
// Project: BenjimsEndgameArmor

using HarmonyLib;
using System;
using UnityEngine;

namespace BenjimsEndgameArmor
{
    internal partial class BenjimsEndgameArmor
    {
        // We want to fix some monster's health and damage values to create a better tier system
        // to go with the Frometal and Flametal weapons and armor.

        [HarmonyPatch]
        public class MonsterPatches
        {
            [HarmonyPatch("RRRCore.Plugin, RRRCore", "LateLoadClient"), HarmonyPostfix]
            public static void LateLoadClientPatch()
            {
                /* Dark Elf Queen - health up by 25% so zerging her down on spawn is less effective
                 * She only has 1,800
                 * Damage done is fine considering number of adds she summons
                 * 
                 * Jotunn - health down by 66%
                 * This guy has 18,000 health by default compared to the Queen's 1,800 health
                 * What an absolute unit
                 * Damage is fine considering he summons no adds
                 * 
                 * All Ashlands mobs + Blazing Damned One
                 * Health up by 150%
                 * Damage up by 100%
                 * Ash Mosquitos need a huge damage boost
                 * Blazing Damned One needs a larger health boosts
                 * */
                EditMonster("RRRM_Jotunn", 6000, 1f);
                EditMonster("RRRM_AshHatchling", 1875, 2f);
                EditMonster("RRRM_AshMosquito", 5, 20f);
                EditMonster("RRRM_AshNeck", 2125, 2f);
                EditMonster("RRRM_BlazingBones", 450, 2f);
                EditMonster("RRRM_BlazingDamnedOne", 3750, 2f);
                EditMonster("RRRM_BurnedBones", 600, 2f);
                EditMonster("RRRM_DamnedOne", 6250, 1f);
                EditMonster("RRRM_ElderSurtling", 200, 2f);
                EditMonster("RRRM_SmallAshNeck", 250, 2f);
                EditMonster("RRRM_SwollenBody", 800, 2f);
            }

            [HarmonyPatch("RRRCore.Plugin, RRRCore", "LateLoadServer"), HarmonyPostfix]
            public static void LateLoadServerPatch()
            {
                EditMonster("RRRM_Jotunn", 6000, 1f);
                EditMonster("RRRM_AshHatchling", 1875, 2f);
                EditMonster("RRRM_AshMosquito", 5, 20f);
                EditMonster("RRRM_AshNeck", 2125, 2f);
                EditMonster("RRRM_BlazingBones", 450, 2f);
                EditMonster("RRRM_BlazingDamnedOne", 3750, 2f);
                EditMonster("RRRM_BurnedBones", 600, 2f);
                EditMonster("RRRM_DamnedOne", 6250, 1f);
                EditMonster("RRRM_ElderSurtling", 200, 2f);
                EditMonster("RRRM_SmallAshNeck", 250, 2f);
                EditMonster("RRRM_SwollenBody", 800, 2f);
            }
        }

        private static void EditMonster(string monster, int newhealth, float newdamagemod)
        {
            try
            {
                if (!ZNetScene.m_instance)
                {
                    return;
                }

                GameObject prefab = ZNetScene.m_instance.GetPrefab(monster);

                if (!prefab)
                {
                    return;
                }
                Jotunn.Logger.LogInfo($"Scaling monster: " + monster);
                // Health is easy to get.  We'll use *= here in case other mods also change the health.
                ZNetScene.m_instance.GetPrefab(monster).GetComponent<Character>().m_health = (newhealth);

                /* Valheim models each attack via an item.  The mobs have weapons, just like players.
                 * Humanoid contains an array, m_defaultItems, of GameObjects which are the mob's weapons.
                 * We can go tunnel into the class structure ItemDrop.ItemData.SharedData.Attack to find
                 * a variable called "damage multiplier" which is 1.0 by default, and acts as one might expect.
                 */
                GameObject[] attacks = ZNetScene.m_instance.GetPrefab(monster).GetComponent<Humanoid>().m_defaultItems;
                foreach(GameObject gobj in attacks)
                {
                        gobj.GetComponent<ItemDrop>().m_itemData.m_shared.m_attack.m_damageMultiplier = (newdamagemod);
                }
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogWarning($"Exception caught while modifying creature scaling: {ex}");
            }
        }
    }
}


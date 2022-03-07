// BenjimsEndgameArmor
// a Valheim mod skeleton using Jötunn
// 
// File:    BenjimsEndgameArmor.cs
// Project: BenjimsEndgameArmor

using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;

namespace BenjimsEndgameArmor
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class BenjimsEndgameArmor : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.BenjimsEndgameArmor";
        public const string PluginName = "Benjims Endgame Armor";
        public const string PluginVersion = "0.0.1";

        private void Awake()
        {
            // MonoMod hooking
            On.FejdStartup.Awake += FejdStartup_Awake;
            // Jotunn logger
            Jotunn.Logger.LogInfo("BenjimsEndgameArmor has landed");
            // Inject our items into the db
            PrefabManager.OnVanillaPrefabsAvailable += AddNewItems;
        }

        private void FejdStartup_Awake(On.FejdStartup.orig_Awake orig, FejdStartup self)
        {
            Jotunn.Logger.LogInfo("FejdStartup is going to awake");
            // Call this method so the original game method is invoked
            orig(self);
            Jotunn.Logger.LogInfo("FejdStartup has awoken");
        }
        private void AddNewItems()
        {
            try
            {
                /*******************
                 Heavymetal Helm
                 *******************/

                CustomItem helmheavymetal = new CustomItem("HelmetHeavymetal", "HelmetPadded", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "If you can stand wearing this disgusting thing, no poison could hurt you.",
                    Name = "Heavymetal Helm",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig
                        {
                            Item = "HeavymetalBar",
                            Amount = 10,
                            AmountPerLevel = 5,
                            Recover = false 
                        },
                        new RequirementConfig
                        { 
                            Item = "WorldTreeFragment",
                            Amount = 15,
                            AmountPerLevel = 10,
                            Recover = false
                        },
                        new RequirementConfig
                        { 
                            Item = "Guck",
                            Amount = 20,
                            AmountPerLevel = 0,
                            Recover = false
                        }
                    }
                });
                ItemManager.Instance.AddItem(helmheavymetal);
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_armor = 36;
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;

                // add poison resist to the helm
                // resists on items are modeled as a list of damage type : resistance pairs of enum classes
                // so we have to construct the pair, add it to a list, then add the list to the item

                HitData.DamageModPair poisonresist = new HitData.DamageModPair
                {
                    m_type = HitData.DamageType.Poison,
                    m_modifier = HitData.DamageModifier.VeryResistant
                };
                List<HitData.DamageModPair> resistlist = new List<HitData.DamageModPair>();
                resistlist.Add(poisonresist);
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_damageModifiers = resistlist;

                /*******************
                 Heavymetal Chest
                 *******************/

                CustomItem armorheavymetalbreastplate = new CustomItem("ArmorHeavymetalBreastplate", "ArmorPaddedCuirass", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "Rugged plate armor stolen from the Mistlands.",
                    Name = "Heavymetal Breastplate",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig
                        {
                            Item = "HeavymetalBar",
                            Amount = 10,
                            AmountPerLevel = 3,
                            Recover = false
                        },
                        new RequirementConfig
                        {
                            Item = "WorldTreeFragment",
                            Amount = 20,
                            AmountPerLevel = 10,
                            Recover = false
                        }
                    }
                });
                ItemManager.Instance.AddItem(armorheavymetalbreastplate);
                armorheavymetalbreastplate.ItemDrop.m_itemData.m_shared.m_armor = 36;
                armorheavymetalbreastplate.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                // remove the speed reduction
                armorheavymetalbreastplate.ItemDrop.m_itemData.m_shared.m_movementModifier = 0;

                /*******************
                Heavymetal Legs
                *******************/

                CustomItem armorheavymetalboots = new CustomItem("ArmorHeavymetalboots", "ArmorPaddedGreaves", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "These are way lighter than they look!",
                    Name = "Heavymetal Boots",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig
                        {
                            Item = "HeavymetalBar",
                            Amount = 10,
                            AmountPerLevel = 3,
                            Recover = false
                        },
                        new RequirementConfig
                        {
                            Item = "WorldTreeFragment",
                            Amount = 20,
                            AmountPerLevel = 10,
                            Recover = false
                        }
                    }
                });
                ItemManager.Instance.AddItem(armorheavymetalboots);
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_armor = 36;
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                // add a little bit of speed!
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_movementModifier = 0.1f;
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                // You want this to run only once, Jotunn has the item(s) cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= AddNewItems;
            }
        }
    }
}


// BenjimsEndgameArmor
// a Valheim mod skeleton using Jötunn
// 
// File:    BenjimsEndgameArmor.cs
// Project: BenjimsEndgameArmor

using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BenjimsEndgameArmor
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal partial class BenjimsEndgameArmor : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.BenjimsEndgameArmor";
        public const string PluginName = "Benjims Endgame Armor";
        public const string PluginVersion = "0.3.1";
        readonly Harmony harmony = new Harmony(PluginGUID);

        private void Awake()
        {
            // MonoMod hooking
            On.FejdStartup.Awake += FejdStartup_Awake;
            // Jotunn logger
            Jotunn.Logger.LogInfo("BenjimsEndgameArmor has landed");
            // Inject our items into the db
            PrefabManager.OnVanillaPrefabsAvailable += AddNewDrops;
            PrefabManager.OnVanillaPrefabsAvailable += AddNewHeavymetalArmor;
            PrefabManager.OnVanillaPrefabsAvailable += AddNewFrometalArmor;
            PrefabManager.OnVanillaPrefabsAvailable += AddNewFlametalArmor;
            // Call harmony for patch classes
            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
        }

        private void FejdStartup_Awake(On.FejdStartup.orig_Awake orig, FejdStartup self)
        {
            Jotunn.Logger.LogInfo("FejdStartup is going to awake");
            // Call this method so the original game method is invoked
            orig(self);
            Jotunn.Logger.LogInfo("FejdStartup has awoken");
        }

        private void AddNewDrops()
        {
            try
            {
                /*******************
                 Frozen Pelt to replace Lox Pelt from RRRM_PolarLox
                 *******************/

                CustomItem frozenpelt = new CustomItem("FrozenPelt", "LoxPelt", new ItemConfig
                {
                    Description = "Thick, wooly, and very smelly.",
                    Name = "Frozen Pelt"
                });
                ItemManager.Instance.AddItem(frozenpelt);

                /*******************
                 Icy Fang to replace Wolf Fang from RRRM_PolarFenring
                 *******************/

                CustomItem icyfang = new CustomItem("IcyFang", "WolfFang", new ItemConfig
                {
                    Description = "As cold as death.",
                    Name = "Icy Fang"
                });
                ItemManager.Instance.AddItem(icyfang);

                /*******************
                 Polar Scale to replace Freeze Gland from RRRM_SmallPolarSerpent
                 They do not seem to drop Serpent Scales, was replaced with Frozen Gland
                 *******************/

                CustomItem polarscale = new CustomItem("PolarScale", "SerpentScale", new ItemConfig
                {
                    Description = "These scales are much harder than the ones from warmer seas.",
                    Name = "Polar Scale"
                });
                ItemManager.Instance.AddItem(polarscale);
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding new drops: {ex.Message}");
            }
            finally
            {
                // You want this to run only once, Jotunn has the item(s) cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= AddNewDrops;
            }
        }
        private void AddNewHeavymetalArmor()
        {
            try
            {
                 // Heavymetal Helm
                CustomItem helmheavymetal = new CustomItem("HelmetHeavymetal", "HelmetPadded", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "Disgusting, but effective.",
                    Name = "Mithril Helm",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "HeavymetalBar", Amount = 10, AmountPerLevel = 5 },
                        new RequirementConfig{ Item = "WorldTreeFragment", Amount = 15, AmountPerLevel = 10 },
                        new RequirementConfig{ Item = "Guck", Amount = 20, AmountPerLevel = 0}
                    }
                });
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_armor = 32;
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_weight = 1;
                /* add poison resist to the helm
                 * resists on items are modeled as a list of damage type : resistance pairs of enum classes
                 * so we have to construct the pair, add it to a list, then add the list to the item */
                HitData.DamageModPair poisonresist = new HitData.DamageModPair
                {
                    m_type = HitData.DamageType.Poison,
                    m_modifier = HitData.DamageModifier.VeryResistant
                };
                List<HitData.DamageModPair> resistlist = new List<HitData.DamageModPair>();
                resistlist.Add(poisonresist);
                helmheavymetal.ItemDrop.m_itemData.m_shared.m_damageModifiers = resistlist;
                ItemManager.Instance.AddItem(helmheavymetal);

                // Heavymetal Chest
                CustomItem armorheavymetalshirt = new CustomItem("ArmorHeavymetalShirt", "ArmorPaddedCuirass", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "The elves' alloy seems impossibly light.",
                    Name = "Mithril Shirt",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "HeavymetalBar", Amount = 10, AmountPerLevel = 3 },
                        new RequirementConfig{ Item = "WorldTreeFragment", Amount = 20, AmountPerLevel = 10 }
                    }
                });
                armorheavymetalshirt.ItemDrop.m_itemData.m_shared.m_armor = 32;
                armorheavymetalshirt.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                armorheavymetalshirt.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                armorheavymetalshirt.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                armorheavymetalshirt.ItemDrop.m_itemData.m_shared.m_weight = 1;
                // remove the speed reduction
                armorheavymetalshirt.ItemDrop.m_itemData.m_shared.m_movementModifier = 0;
                ItemManager.Instance.AddItem(armorheavymetalshirt);

                // Heavymetal Legs
                CustomItem armorheavymetalboots = new CustomItem("ArmorHeavymetalBoots", "ArmorPaddedGreaves", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "The elves' speed must be magically enchanced.  You won't be as fast, but these will help.",
                    Name = "Mithril Boots",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "HeavymetalBar", Amount = 10, AmountPerLevel = 3},
                        new RequirementConfig{ Item = "WorldTreeFragment", Amount = 20, AmountPerLevel = 10 }
                    }
                });
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_armor = 32;
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_weight = 1;
                // add a little bit of speed!
                armorheavymetalboots.ItemDrop.m_itemData.m_shared.m_movementModifier = 0.15f;
                ItemManager.Instance.AddItem(armorheavymetalboots);
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding new armor: {ex.Message}");
            }
            finally
            {
                // You want this to run only once, Jotunn has the item(s) cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= AddNewHeavymetalArmor;
            }
        }
        private void AddNewFrometalArmor()
        {
            try
            {
                // HelmetFrometal
                CustomItem helmfrometal = new CustomItem("HelmetFrometal", "HelmetPadded", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "The fur will help protect you from extreme temperatures, but it sure does smell bad...",
                    Name = "Frostscale Helm",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "FrometalBar", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig{ Item = "PolarScale", Amount = 6, AmountPerLevel = 3 },
                        new RequirementConfig{ Item = "FrozenPelt", Amount = 6, AmountPerLevel = 3}
                    }
                });

                // add frost and fire resist
                HitData.DamageModPair fireresist = new HitData.DamageModPair
                {
                    m_type = HitData.DamageType.Fire,
                    m_modifier = HitData.DamageModifier.Resistant
                };
                HitData.DamageModPair frostresist = new HitData.DamageModPair
                {
                    m_type = HitData.DamageType.Frost,
                    m_modifier = HitData.DamageModifier.Resistant
                };
                List<HitData.DamageModPair> resistlist = new List<HitData.DamageModPair>();
                resistlist.Add(fireresist);
                resistlist.Add(frostresist);
                helmfrometal.ItemDrop.m_itemData.m_shared.m_damageModifiers = resistlist;
                helmfrometal.ItemDrop.m_itemData.m_shared.m_armor = 38;
                helmfrometal.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                helmfrometal.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                helmfrometal.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                ItemManager.Instance.AddItem(helmfrometal);

                // ChestFrometal
                CustomItem chestfrometal = new CustomItem("ArmorFrometalHauberk", "ArmorPaddedCuirass", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "The insulated scales cling to your body, keeping you dry.",
                    Name = "Frostscale Hauberk",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "FrometalBar", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig{ Item = "PolarScale", Amount = 10, AmountPerLevel = 5 },
                        new RequirementConfig{ Item = "FrozenPelt", Amount = 10, AmountPerLevel = 5}
                    }
                });
                // Wet immunity provided in ItemEffects via postfix
                chestfrometal.ItemDrop.m_itemData.m_shared.m_armor = 38;
                chestfrometal.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                chestfrometal.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                chestfrometal.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                ItemManager.Instance.AddItem(chestfrometal);

                // BootsFrometal
                CustomItem bootsfrometal = new CustomItem("ArmorFrometalBoots", "ArmorPaddedGreaves", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "Are those webbed toes?",
                    Name = "Frostscale Boots",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "FrometalBar", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig{ Item = "PolarScale", Amount = 6, AmountPerLevel = 3 },
                        new RequirementConfig{ Item = "FrozenPelt", Amount = 6, AmountPerLevel = 3}
                    }
                });

                // add swim skill modifier, and as a hidden effect increase swim speed drastically via a
                // harmony patch to whatever method gets swim speed, or if none just jack it up

                bootsfrometal.ItemDrop.m_itemData.m_shared.m_armor = 38;
                bootsfrometal.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                bootsfrometal.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                bootsfrometal.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                ItemManager.Instance.AddItem(bootsfrometal);
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding new armor: {ex.Message}");
            }
            finally
            {
                // You want this to run only once, Jotunn has the item(s) cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= AddNewFrometalArmor;
            }
        }

        private void AddNewFlametalArmor()
        {
            try
            {
                // Flametal Helm
                CustomItem helmflametal = new CustomItem("HelmetFlametal", "HelmetPadded", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "The eerie light emitting from the helm tints the world around you in red.",
                    Name = "Flametal Helm",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "Flametal", Amount = 10, AmountPerLevel = 5 },
                        new RequirementConfig{ Item = "BurningWorldTreeFragment", Amount = 15, AmountPerLevel = 10 },
                        new RequirementConfig{ Item = "SurtlingCore", Amount = 10, AmountPerLevel = 0}
                    }
                });

                // Add a glow like a torch

                helmflametal.ItemDrop.m_itemData.m_shared.m_armor = 44;
                helmflametal.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                helmflametal.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                helmflametal.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                ItemManager.Instance.AddItem(helmflametal);

                // Flametal Chest
                CustomItem armorflametalbreastplate = new CustomItem("ArmorFlametalBreastplate", "ArmorPaddedCuirass", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "The thick plate seems to soak in energy around it.",
                    Name = "Flametal Breastplate",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "Flametal", Amount = 10, AmountPerLevel = 3 },
                        new RequirementConfig{ Item = "BurningWorldTreeFragment", Amount = 20, AmountPerLevel = 10 },
                        new RequirementConfig{ Item = "SurtlingCore", Amount = 15, AmountPerLevel = 0}
                    }
                });

                // Add fire resist
                HitData.DamageModPair fireveryresist = new HitData.DamageModPair
                {
                    m_type = HitData.DamageType.Fire,
                    m_modifier = HitData.DamageModifier.VeryResistant
                };
                List<HitData.DamageModPair> resistlist = new List<HitData.DamageModPair>();
                resistlist.Add(fireveryresist);
                armorflametalbreastplate.ItemDrop.m_itemData.m_shared.m_damageModifiers = resistlist;
                armorflametalbreastplate.ItemDrop.m_itemData.m_shared.m_armor = 44;
                armorflametalbreastplate.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                armorflametalbreastplate.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                armorflametalbreastplate.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                ItemManager.Instance.AddItem(armorflametalbreastplate);

                // Flametal Legs
                CustomItem armorflametalboots = new CustomItem("ArmorFlametalGreaves", "ArmorPaddedGreaves", new ItemConfig
                {
                    CraftingStation = "piece_thorsforge",
                    Description = "These boots melt into the ground, making it harder to move.  Or be moved...",
                    Name = "Flametal Greaves",
                    RepairStation = "piece_thorsforge",
                    Requirements = new[]
                    {
                        new RequirementConfig{ Item = "Flametal", Amount = 10, AmountPerLevel = 3},
                        new RequirementConfig{ Item = "BurningWorldTreeFragment", Amount = 20, AmountPerLevel = 10 },
                        new RequirementConfig{ Item = "SurtlingCore", Amount = 10, AmountPerLevel = 0}
                    }
                });

                // reduce move speed by and additional 10%, and reduce the amount you can be knocked around by 90%
                // the second part will probably require a patch
                
                // note, base move speed reduction is -5%, so these will need to be set to -15%

                armorflametalboots.ItemDrop.m_itemData.m_shared.m_armor = 44;
                armorflametalboots.ItemDrop.m_itemData.m_shared.m_armorPerLevel = 2;
                armorflametalboots.ItemDrop.m_itemData.m_shared.m_maxDurability = 1500;
                armorflametalboots.ItemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500;
                ItemManager.Instance.AddItem(armorflametalboots);
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding new armor: {ex.Message}");
            }
            finally
            {
                // You want this to run only once, Jotunn has the item(s) cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= AddNewFlametalArmor;
            }
        }
    }
}


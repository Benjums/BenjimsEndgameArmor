// BenjimsEndgameArmor
// a Valheim mod skeleton using Jötunn
// 
// File:    BenjimsEndgameArmor.cs
// Project: BenjimsEndgameArmor

using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace BenjimsEndgameArmor
{
    internal partial class BenjimsEndgameArmor
    {
        /* We want to modify some of the Epic Valheim Additions recipes to make use of our custom items.
         * Recipes are stored in ObjectDB with a GetRecipe method that can be used to extract them and will give access
         * to the array of PieceRequirements which is a public field and can be overwritten.  The GetRecipe method takes
         * ItemDrop.ItemData as input and compares a string name field.  To get the recipe we want, all we have to do
         * is make a new ItemDrop.ItemData with the proper m_shared.m_name string. 
         */
        [HarmonyPatch]
        public class EpicValheimRecipePatches
        {
            // format of this line is "MainClassInsideDLL.ClassToPatch, DLLName", "MethodToPatch"
            [HarmonyPatch("EpicValheimsAdditions.Core, EpicValheimsAdditions", "RegisterFrometalWeapons"), HarmonyPostfix]
            public static void RegisterFrometalWeaponsPatch()
            {
                // BowFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_BowFrometal");
                CustomRecipe newbow = new CustomRecipe(new RecipeConfig()
                {
                    Name = "Frometal Bow",
                    Item = "BowFrometal",
                    CraftingStation = "piece_thorsforge",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 15, AmountPerLevel = 7 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 5, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "IcyFang", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newbow);

                // AtgeirFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_AtgeirFrometal");
                CustomRecipe newatgeir = new CustomRecipe(new RecipeConfig()
                {
                    Item = "AtgeirFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Atgeir",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 15, AmountPerLevel = 7 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 5, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "IcyFang", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 6, AmountPerLevel = 3 }
                    }
                });
                ItemManager.Instance.AddRecipe(newatgeir);

                // SledgeFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_SledgeFrometal");
                CustomRecipe newsledge = new CustomRecipe(new RecipeConfig()
                {
                    Item = "SledgeFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Sledge",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 15, AmountPerLevel = 7 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 7, AmountPerLevel = 3 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newsledge);

                // BattleaxeFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_BattleaxeFrometal");
                CustomRecipe newbattleaxe = new CustomRecipe(new RecipeConfig()
                {
                    Item = "BattleaxeFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Battleaxe",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 15, AmountPerLevel = 7 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 5, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 10, AmountPerLevel = 6 }
                    }
                });
                ItemManager.Instance.AddRecipe(newbattleaxe);

                // SpearFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_SpearFrometal");
                CustomRecipe newspear = new CustomRecipe(new RecipeConfig()
                {
                    Item = "SpearFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Spear",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 10, AmountPerLevel = 5 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 5, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "IcyFang", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newspear);

                // KnifeFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_KnifeFrometal");
                CustomRecipe newknife = new CustomRecipe(new RecipeConfig()
                {
                    Item = "KnifeFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Knife",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 8, AmountPerLevel = 4 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "IcyFang", Amount = 3, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 2, AmountPerLevel = 1 }
                    }
                });
                ItemManager.Instance.AddRecipe(newknife);

                // MaceFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_MaceFrometal");
                CustomRecipe newmace = new CustomRecipe(new RecipeConfig()
                {
                    Item = "MaceFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Mace",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 10, AmountPerLevel = 5 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 5, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "IcyFang", Amount = 3, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newmace);

                // GreatSwordFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_GreatSwordFrometal");
                CustomRecipe newgreatsword = new CustomRecipe(new RecipeConfig()
                {
                    Item = "GreatSwordFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Great Sword",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 30, AmountPerLevel = 15 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 10, AmountPerLevel = 5 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newgreatsword);

                // SwordFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_SwordFrometal");
                CustomRecipe newsword = new CustomRecipe(new RecipeConfig()
                {
                    Item = "SwordFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Sword",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 15, AmountPerLevel = 7 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 7, AmountPerLevel = 3 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 2, AmountPerLevel = 1 }
                    }
                });
                ItemManager.Instance.AddRecipe(newsword);

                // ShieldFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_ShieldFrometal");
                CustomRecipe newshield = new CustomRecipe(new RecipeConfig()
                {
                    Item = "ShieldFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Shield",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 8, AmountPerLevel = 4 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 5, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newshield);

                // ShieldFrometalTower
                ItemManager.Instance.RemoveRecipe("Recipe_ShieldFrometalTower");
                CustomRecipe newtowershield = new CustomRecipe(new RecipeConfig()
                {
                    Item = "ShieldFrometalTower",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Tower Shield",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 12, AmountPerLevel = 6 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 7, AmountPerLevel = 3 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newtowershield);

                // AxeFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_AxeFrometal");
                CustomRecipe newaxe = new CustomRecipe(new RecipeConfig()
                {
                    Item = "AxeFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Axe",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 20, AmountPerLevel = 10 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 3, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "IcyFang", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newaxe);

                // PickaxeFrometal
                ItemManager.Instance.RemoveRecipe("Recipe_PickaxeFrometal");
                CustomRecipe newpickaxe = new CustomRecipe(new RecipeConfig()
                {
                    Item = "PickaxeFrometal",
                    CraftingStation = "piece_thorsforge",
                    Name = "Frometal Pickaxe",
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        new RequirementConfig { Item = "FrometalBar", Amount = 4, AmountPerLevel = 2 },
                        new RequirementConfig { Item = "PrimordialIce", Amount = 2, AmountPerLevel = 1 },
                        new RequirementConfig { Item = "IcyFang", Amount = 8, AmountPerLevel = 4 },
                        new RequirementConfig { Item = "WorldTreeFragment", Amount = 4, AmountPerLevel = 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newpickaxe);
                Jotunn.Logger.LogInfo($"Edited Frometal weapon recipies!");
            }
            // format of this line is "MainClassInsideDLL.ClassToPatch, DLLName", "MethodToPatch"
            [HarmonyPatch("EpicValheimsAdditions.Core, EpicValheimsAdditions", "RegisterFlametalWeapons"), HarmonyPostfix]
            public static void RegisterFlametalWeaponsPatch()
            {
                flametalweaponhelper("Bow",20,4,8);
                flametalweaponhelper("Atgeir", 20, 4, 8);
                flametalweaponhelper("Sledge", 20, 4, 8);
                flametalweaponhelper("Battleaxe", 20, 6, 10);
                flametalweaponhelper("Spear", 10, 2, 4);
                flametalweaponhelper("Knife", 8, 2, 2);
                flametalweaponhelper("Mace", 10, 2, 4);
                flametalweaponhelper("Greatsword", 30, 6, 10);
                flametalweaponhelper("Sword", 10, 2, 4);
                flametalweaponhelper("Shield", 10, 2, 4);
                flametalweaponhelper("Tower", 12, 6, 8);
                flametalweaponhelper("Axe", 10, 2, 4);
                flametalweaponhelper("Pickaxe", 20, 4, 8);
                Jotunn.Logger.LogInfo($"Edited Flametal weapon recipies!");

            }

            // "weapon" is the weapon type, like Axe or Bow.  Capitalization counts here!
            public static void flametalweaponhelper(string weapon, int flametal, int cores, int fragments)
            {
                string recipe;
                string prefab;
                string name;
                // the tower shield uses a different naming convention from the other items
                if(weapon == "Tower")
                {
                    recipe = "Recipe_ShieldFlametalTower";
                    prefab = "ShieldFlametalTower";
                    name = "Flametal Tower Shield";
                }
                else
                {
                    recipe = "Recipe_" + weapon + "Flametal";
                    prefab = weapon + "Flametal";
                    name = "Flametal " + weapon;
                }
                ItemManager.Instance.RemoveRecipe(recipe);
                CustomRecipe newweapon = new CustomRecipe(new RecipeConfig()
                {
                    Item = prefab,
                    CraftingStation = "piece_thorsforge",
                    Name = name,
                    RepairStation = "piece_thorsforge",
                    Requirements = new RequirementConfig[]
                    {
                        // integer division works here
                        new RequirementConfig { Item = "Flametal", Amount = flametal, AmountPerLevel = flametal / 2 },
                        new RequirementConfig { Item = "SurtlingCore", Amount = cores, AmountPerLevel = cores / 2 },
                        new RequirementConfig { Item = "BurningWorldTreeFragment", Amount = fragments, AmountPerLevel = fragments / 2 }
                    }
                });
                ItemManager.Instance.AddRecipe(newweapon);
            }
        }
    }
}


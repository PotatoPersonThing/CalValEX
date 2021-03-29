using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class RepurposedMonitor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Repurposed Monitor");
            Tooltip.SetDefault("Summons a faulty repair bot to follow you");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item15;
            item.shoot = mod.ProjectileType("RepairBot");
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 4;
            item.buffType = mod.BuffType("RepurposedMonitorBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(204, 71, 35); //change the color accordingly to above
                }
            }
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("Navyplate"), 15);
                    recipe.AddTile(TileID.Anvils);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("Chaosplate"), 15);
                    recipe.AddTile(TileID.Anvils);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("Cinderplate"), 15);
                    recipe.AddTile(TileID.Anvils);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("Elumplate"), 15);
                    recipe.AddTile(TileID.Anvils);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("PlagueContainmentCells"), 15);
                    recipe.AddTile(TileID.Anvils);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
            }
        }
    }
}
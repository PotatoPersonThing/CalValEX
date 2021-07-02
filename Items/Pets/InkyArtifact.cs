using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class InkyArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inky Artifact");
            Tooltip.SetDefault("For Omega version 50% off!!");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit13;
            item.shoot = mod.ProjectileType("OmegaSquid");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("OmegaSquidBuff");
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
                    tooltipLine.overrideColor = new Color(0, 255, 0); //change the color accordingly to above
                }
            }
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            {
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("HalibutCannon"), 1);
                    recipe.AddIngredient(mod.ItemType("Pollution"), 1);
                    recipe.AddTile(TileID.LunarCraftingStation);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(calamityMod.ItemType("Lumenite"), 3996);
                    recipe.AddIngredient(calamityMod.ItemType("DepthCells"), 3996);
                    recipe.AddIngredient(calamityMod.ItemType("Tenebris"), 3996);
                    recipe.AddIngredient(calamityMod.ItemType("ReaperTooth"), 3996);
                    recipe.AddIngredient(calamityMod.ItemType("EidolicWail"), 5);
                    recipe.AddIngredient(calamityMod.ItemType("Valediction"), 5);
                    recipe.AddIngredient(calamityMod.ItemType("CalamarisLament"), 5);
                    recipe.AddIngredient(calamityMod.ItemType("Reaper"), 2);
                    recipe.AddIngredient(calamityMod.ItemType("SoulEdge"), 5);
                    recipe.AddIngredient(mod.ItemType("Pollution"), 1);
                    recipe.AddTile(TileID.LunarCraftingStation);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
            }
        }
    }
}
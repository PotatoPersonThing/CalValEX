using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    internal class RespirationShrine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Respiration Shrine");
            Tooltip
                .SetDefault("Provides infinite breath in the Abyss within a certain radius, for your Abyss base needs.\n" + "Deactivating will near instantly cause you to start drowning\n" + "Basically cheating.");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<RespirationShrinePlaced>();
            item.width = 50;
            item.height = 64;
            item.rare = ItemRarityID.Cyan;
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
                    tooltipLine.overrideColor = new Color(255, 0, 255); //change the color accordingly to above
                }
            }
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Lumenite"), 333);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Voidstone"), 200);
                recipe.AddIngredient((ItemID.Ectoplasm), 100);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CalamitousEssence"), 100);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
                recipe.SetResult(this);
                recipe.AddRecipe();
                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("HalibutCannon"));
                recipe2.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
                recipe2.SetResult(this);
                recipe2.AddRecipe();
            }
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class PutridShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armoatic Shroom");
            Tooltip.SetDefault("Causes the great fungus crab's Crab Shrooms to become passive, but also enrage upon defeat\n" + "Keeps the small fungal crab on your head, even when moving\n" + "'Smells like cheese...?'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.maxStack = 1;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((ItemID.VileMushroom), 5);
            recipe.AddIngredient((ItemID.GlowingMushroom), 5);
            recipe.AddIngredient((ItemID.Bottle), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient((ItemID.ViciousMushroom), 5);
            recipe2.AddIngredient((ItemID.GlowingMushroom), 5);
            recipe2.AddIngredient((ItemID.Bottle), 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
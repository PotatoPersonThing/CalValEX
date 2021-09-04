using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class OldCassette : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Cassette");
            Tooltip.SetDefault("Favorite this item to activate player afterimages\n" + "'It contains some edgy anime episodes from the 90's'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 20));
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = false;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.maxStack = 1;
            item.rare = ItemRarityID.Blue;
        }
        public override void UpdateInventory(Player player)
        {
            if (item.favorited)
            {
                player.armorEffectDrawShadow = true;
                player.armorEffectDrawOutlines = true;
                player.GetModPlayer<CalValEXPlayer>().cassette = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((ItemID.ShadowScale), 5);
            recipe.AddIngredient((ItemID.Diamond), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient((ItemID.TissueSample), 5);
            recipe2.AddIngredient((ItemID.Diamond), 5);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
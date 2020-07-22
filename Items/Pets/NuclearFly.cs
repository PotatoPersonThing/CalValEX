using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using CalValEX.Items.Critters;

namespace CalValEX.Items.Pets
{
    public class NuclearFly : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Fly");
            Tooltip
                .SetDefault("Ascension");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit49;
            item.shoot = mod.ProjectileType("Godrge");
            item.value = Item.sellPrice(1, 0, 1, 0);
            item.rare = 10;
            item.expert = true;
            item.buffType = mod.BuffType("GodrgeBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override void AddRecipes()
            {
             Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 20);
				recipe.AddIngredient(ModContent.ItemType<NukeFlyItem>(), 1);
                recipe.AddIngredient(ModContent.ItemType<BubbleGum>(), 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
        }
    }
}

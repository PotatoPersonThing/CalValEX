using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class SparrowMeat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparrow Meat");
            Tooltip.SetDefault("There's a bit of pink cloth in it");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.rare = 11;
            item.value = Item.sellPrice(0, 30, 20, 0);
            item.buffType = BuffID.WellFed; //Specify an existing buff to be applied when used.
            item.buffTime = 300; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmicDischarge"), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("HolyCollider"), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BansheeHook"), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StreamGouge"), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SoulEdge"), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Valediction"), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
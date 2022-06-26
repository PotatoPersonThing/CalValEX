using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Mounts;

namespace CalValEX.Items.Mounts.Ground
{
    public class ProfanedCycleItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Profaned Cycle");
            SacrificeTotal = 1;
            Tooltip.SetDefault("When you need to get somewhere, in style.\nThe Profaned Goddess' curse haunts the cycle, cutting your damage and health dramatically if a boss is nearby");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.UseSound = SoundID.Item23;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<ProfanedCycle>();
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
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(0, 255, 200); //change the color accordingly to above
                }
            }
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ProfanedWheels"));
            recipe.AddIngredient(mod.ItemType("ProfanedFrame"));
            recipe.AddIngredient(mod.ItemType("ProfanedBattery"));
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("DivineGeode"), 5);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar"), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
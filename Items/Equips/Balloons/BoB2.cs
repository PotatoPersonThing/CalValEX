using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class BoB2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bundle of Water Balloons");
            Tooltip.SetDefault("The Party Girl can tie this for you\n'How did none of them pop down there?'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Purple;
            item.accessory = true;
            item.vanity = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(0, 255, 0);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BoxBalloon>());
            recipe.AddIngredient(ModContent.ItemType<ChaosBalloon>());
            recipe.AddIngredient(ModContent.ItemType<Mirballoon>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
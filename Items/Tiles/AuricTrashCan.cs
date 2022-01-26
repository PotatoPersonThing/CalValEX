using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.FurnitureSets.Auric;

namespace CalValEX.Items.Tiles
{
    public class AuricTrashCan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Trash Can");
            Tooltip.SetDefault("I've lost control of my life");
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
            item.createTile = ModContent.TileType<AuricTrashCanPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 11;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.Violet, tooltips);
        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TrashCan);
            recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 4);
                recipe.AddTile(ModContent.TileType<AuricManufacturerPlaced>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;
using Terraria.ID;
//using CalValEX.Tiles.FurnitureSets.Auric;

namespace CalValEX.Items.Tiles
{
    public class AuricTrashCan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Trash Can");
            Tooltip.SetDefault("I've lost control of my life");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AuricTrashCanPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 11;
        }

        //public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.Violet, tooltips);
       /* public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TrashCan);
            recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 4);
            recipe.AddTile(ModContent.TileType<AuricManufacturerPlaced>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
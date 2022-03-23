using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles
{
    public class BrokenArsenalPlantItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arsenal plantjkfasjdfbasjk");
            Tooltip.SetDefault("idfk lolo");
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
            item.createTile = ModContent.TileType<BrokenArsenalPlant>();
            item.width = 12;
            item.height = 12;
            item.rare = 11;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.Violet, tooltips);
    }
}
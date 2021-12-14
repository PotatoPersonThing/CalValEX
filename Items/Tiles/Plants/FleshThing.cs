using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.Plants;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Plants
{
    internal class FleshThing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Grass");
            Tooltip.SetDefault("A strange fleshy substance birthed by the crimson and cared for by Dreadon");
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
            item.createTile = ModContent.TileType<FleshThingPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 2;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.DedicatedEX, tooltips);
    }
}
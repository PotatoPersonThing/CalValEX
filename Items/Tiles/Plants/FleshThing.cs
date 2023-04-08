using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.Plants;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Plants
{
    public class FleshThing : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Living Grass");
            // Tooltip.SetDefault("A strange fleshy substance birthed by the crimson and cared for by Draedon");
            Item.ResearchUnlockCount = 1;
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
            Item.createTile = ModContent.TileType<FleshThingPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 2;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.DedicatedEX, tooltips);
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalValEX.Tiles.Plants;
using Terraria.ModLoader;
using Terraria;

namespace CalValEX.Items.Tiles.Plants
{
    public class PottedDecapoditaSprout : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potted Decapodita Sprout");
            Tooltip.SetDefault("Fungus");
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
            item.createTile = ModContent.TileType<DecapoditaSproutPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 2;
        }
    }
}
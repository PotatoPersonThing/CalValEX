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
            SacrificeTotal = 1;
            Tooltip.SetDefault("Fungus");
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
            Item.createTile = ModContent.TileType<DecapoditaSproutPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 2;
        }
    }
}
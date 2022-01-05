using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Plants;

namespace CalValEX.Items.Tiles.Plants
{
    public class SulphurousPlanter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Vine Planter");
            Tooltip
                .SetDefault("You are baffled by how they are standing up");
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
            item.createTile = ModContent.TileType<SulphurousPlanterPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 7;
        }
    }
}
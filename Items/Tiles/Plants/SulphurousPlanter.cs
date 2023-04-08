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
            // DisplayName.SetDefault("Acid Vine Planter");
            /* Tooltip
                .SetDefault("You are baffled by how they are standing up"); */
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
            Item.createTile = ModContent.TileType<SulphurousPlanterPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 7;
        }
    }
}